namespace PulseGenerator.Channel
{
    using System;
    using System.Threading;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    using Prism.Mvvm;

    using PulseGenerator.Communication;
    using PulseGenerator.Helper;

    /// <summary>
    ///     The channel data for view.
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    public class ChannelDataForView : BindableBase
    {
        #region Constants

        private const int Period = 500;

        #endregion

        private readonly SolidColorBrush green = new SolidColorBrush(Colors.Green);

        private readonly SolidColorBrush lightGreen = new SolidColorBrush(Colors.LightGreen);

        private readonly SolidColorBrush red = new SolidColorBrush(Colors.Red);

        private SolidColorBrush color;

        private uint stops;

        private uint stopTime;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelDataForView" /> class.
        /// </summary>
        /// <param name="name">The name info.</param>
        /// <param name="send">The send service.</param>
        /// <param name="readEventHandler">The read event handler.</param>
        public ChannelDataForView(uint name, ISend send, IReadEventHandler readEventHandler)
        {
            this.Name = name;
            this.Send = send;
            this.SetActionCommand = new RelayCommand(this.SetActionCommandAction);
            this.StopTime = 10;
            this.Stops = 20;

            this.Color = this.red;
            readEventHandler.EventIsReached += this.ReadEventHandler_EventIsReached;

            this.Timer = new Timer(this.TimerCallback, null, 0, Period);
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the color.
        /// </summary>
        /// <value>
        ///     The color.
        /// </value>
        public SolidColorBrush Color
        {
            get => this.color;

            set => this.SetProperty(ref this.color, value);
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name info.
        /// </value>
        public uint Name { get; }

        /// <summary>
        ///     Gets the set action command.
        /// </summary>
        /// <value>
        ///     The set action command.
        /// </value>
        public ICommand SetActionCommand { get; }

        /// <summary>
        ///     Gets or sets the check sum.
        /// </summary>
        /// <value>
        ///     The check sum.
        /// </value>
        public uint Stops
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
        public uint StopTime
        {
            get => this.stopTime;

            set => this.SetProperty(ref this.stopTime, value);
        }

        private ISend Send { get; }

        private Timer Timer { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Sets the action command action.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void SetActionCommandAction(object obj)
        {
            try
            {
                this.Send.Do(this.Name, this.Stops, this.StopTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{this.Name};{this.Stops};{this.StopTime}";
        }

        #endregion

        #region Private Methods

        private void TimerCallback(object obj)
        {
            try
            {
                this.Color = this.red;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ReadEventHandler_EventIsReached(object sender, ReadArgumentsArgs e)
        {
            try
            {
                if (e.Channel.Equals(this.Name))
                {
                    if (e.Stops.Equals(this.Stops) && e.BreakTime.Equals(this.StopTime))
                    {
                        this.Timer.Change(0, Period);
                        this.Color = this.Color == this.green ? this.lightGreen : this.green;
                    }
                    else
                    {
                        this.Color = this.red;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}