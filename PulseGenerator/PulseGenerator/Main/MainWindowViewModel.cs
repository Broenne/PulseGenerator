namespace PulseGenerator.Main
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using Prism.Mvvm;

    using PulseGenerator.Channel;
    using PulseGenerator.Communication;
    using PulseGenerator.Helper;
    using PulseGenerator.InitData;

    /// <summary>
    ///     The main window view model.
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    /// <seealso cref="PulseGenerator.Main.IMainWindowViewModel" />
    public class MainWindowViewModel : BindableBase, IMainWindowViewModel
    {
        private List<string> comPorts;

        private bool isEnabled;

        private string selected;

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        /// <param name="channelView">The channel view.</param>
        /// <param name="isConnectedHandler">The is connected handler.</param>
        /// <param name="send">The send service.</param>
        /// <param name="save">The save service.</param>
        public MainWindowViewModel(IChannelView channelView, IIsConnectedHandler isConnectedHandler, ISend send, ISave save)
        {
            this.WindowLoadCommand = new RelayCommand(this.WindowLoadCommandAction);
            this.RefreshCommand = new RelayCommand(this.RefreshCommandAction);
            this.OpenValueCommand = new RelayCommand(this.OpenValueCommandAction);
            this.DisconnectCommand = new RelayCommand(this.DisconnectCommandAction);

            this.IsEnabled = true;

            this.ChannelView = channelView;
            isConnectedHandler.EventIsReached += this.IsConnectedHandler_EventIsReached;

            this.Send = send;
            this.Save = save;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the channel view.
        /// </summary>
        /// <value>
        ///     The channel view.
        /// </value>
        public IChannelView ChannelView { get; }

        /// <summary>
        ///     Gets or sets the COM ports.
        /// </summary>
        /// <value>
        ///     The COM ports.
        /// </value>
        public List<string> ComPorts
        {
            get => this.comPorts;
            set => this.SetProperty(ref this.comPorts, value);
        }

        /// <summary>
        ///     Gets the disconnect command.
        /// </summary>
        /// <value>
        ///     The disconnect command.
        /// </value>
        public ICommand DisconnectCommand { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetProperty(ref this.isEnabled, value);
        }

        /// <summary>
        ///     Gets the open value command.
        /// </summary>
        /// <value>
        ///     The open value command.
        /// </value>
        public ICommand OpenValueCommand { get; }

        /// <summary>
        ///     Gets the refresh command.
        /// </summary>
        /// <value>
        ///     The refresh command.
        /// </value>
        public ICommand RefreshCommand { get; }

        /// <summary>
        ///     Gets or sets the selected.
        /// </summary>
        /// <value>
        ///     The selected.
        /// </value>
        public string Selected
        {
            get => this.selected;
            set => this.SetProperty(ref this.selected, value);
        }

        /// <summary>
        ///     Gets or sets the window load command.
        /// </summary>
        /// <value>
        ///     The window load command.
        /// </value>
        public ICommand WindowLoadCommand { get; set; }

        private ISave Save { get; }

        private ISend Send { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            // kein try catch, dann ist eh zu spät
            this.DisconnectCommandAction(null);
        }

        #endregion

        #region Private Methods

        private void IsConnectedHandler_EventIsReached(object sender, bool e)
        {
            try
            {
                this.IsEnabled = !e;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenValueCommandAction(object obj)
        {
            try
            {
                var comPort = (string)obj;

                if (string.IsNullOrEmpty(comPort))
                {
                    MessageBox.Show("Please select com port");
                    return;
                }

                this.Send.Open(comPort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadComports()
        {
            this.ComPorts = new List<string>();
            this.ComPorts = SerialPort.GetPortNames().ToList();
            this.Selected = this.ComPorts.FirstOrDefault();
        }

        private void RefreshCommandAction(object obj)
        {
            try
            {
                this.LoadComports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisconnectCommandAction(object obj)
        {
            try
            {
                this.Send.Close();

                var initList = this.ChannelView?.GetDataContext()?.GetInfos();
                this.Save.Do(initList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WindowLoadCommandAction(object obj)
        {
            try
            {
                this.RefreshCommandAction(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}