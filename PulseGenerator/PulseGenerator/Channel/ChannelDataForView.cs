namespace PulseGenerator.Channel
{
    using System;
    using System.Windows;
    using System.Windows.Input;using Prism.Mvvm;

    using PulseGenerator.Helper;

    /// <summary>#
    /// The channel data for view.
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    public class ChannelDataForView : BindableBase
    {
        private int stops;

        private int stopTime;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelDataForView"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ChannelDataForView(string name)
        {
            this.Name = name;
            this.SetActionCommand = new RelayCommand(this.SetActionCommandAction);
            this.StopTime = 10;
            this.Stops = 20;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name info.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the set action command.
        /// </summary>
        /// <value>
        /// The set action command.
        /// </value>
        public ICommand SetActionCommand { get; }

        /// <summary>
        ///     Gets or sets the check sum.
        /// </summary>
        /// <value>
        ///     The check sum.
        /// </value>
        public int Stops
        {
            get => this.stops;

            set => this.SetProperty(ref this.stops, value);
        }

        /// <summary>
        ///     Gets or sets the check sum.
        /// </summary>
        /// <value>
        ///     The check sum.
        /// </value>
        public int StopTime
        {
            get => this.stopTime;

            set => this.SetProperty(ref this.stopTime, value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the action command action.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void SetActionCommandAction(object obj)
        {
            try
            {
                Console.WriteLine($"Send action channel:{this.Name} Stops:{this.Stops} stoptime:{this.StopTime}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}