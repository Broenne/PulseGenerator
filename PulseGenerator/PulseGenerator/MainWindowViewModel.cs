namespace PulseGenerator
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    using Helper;

    using Prism.Mvvm;

    using PulseGenerator.Channel;
    using PulseGenerator.Main;

    /// <summary>
    ///     The main window view model.
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    /// <seealso cref="PulseGenerator.Main.IMainWindowViewModel" />
    public class MainWindowViewModel : BindableBase, IMainWindowViewModel
    {
        private List<string> comPorts;

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel(IChannelView channelView, IIsConnectedHandler isConnectedHandler)
        {
            this.WindowLoadCommand = new RelayCommand(this.WindowLoadCommandAction);
            this.RefreshCommand = new RelayCommand(this.RefreshCommandAction);
            this.OpenValueCommand = new RelayCommand(this.OpenValueCommandAction);
            this.DisconnectCommand = new RelayCommand(this.DisconnectCommandAction);

            this.ChannelView = channelView;
            this.IsConnectedHandler = isConnectedHandler;
        }

        #endregion

        #region Properties


        public IIsConnectedHandler IsConnectedHandler { get; }

        /// <summary>
        ///     Gets or sets the COM ports.
        /// </summary>
        /// <value>
        ///     The COM ports.
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
        ///     Gets or sets the window load command.
        /// </summary>
        /// <value>
        ///     The window load command.
        /// </value>
        public ICommand WindowLoadCommand { get; set; }

        private SerialPort SerialPort { get; set; }

        #endregion

        #region Private Methods

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

                this.SerialPort = new SerialPort();
                this.SerialPort.BaudRate = 115200;
                this.SerialPort.PortName = comPort;
                this.SerialPort.Close();
                this.SerialPort.Open();
                this.SerialPort.ReadTimeout = 200;

                this.IsConnectedHandler.OnReached(this.SerialPort.IsOpen);
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
                this.SerialPort.Close();
                
                this.IsConnectedHandler.OnReached(false);
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