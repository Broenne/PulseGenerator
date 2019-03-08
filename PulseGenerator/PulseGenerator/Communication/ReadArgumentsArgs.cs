namespace PulseGenerator.Communication
{
    using System;

    /// <summary>
    ///     The read arguments.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ReadArgumentsArgs : EventArgs
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ReadArgumentsArgs" /> class.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="stops">The stops.</param>
        /// <param name="breakTime">The break time.</param>
        public ReadArgumentsArgs(uint channel, uint stops, uint breakTime)
        {
            this.Channel = channel;
            this.Stops = stops;
            this.BreakTime = breakTime;
        }
      
        #endregion

        #region Properties

        /// <summary>
        ///     Gets the break time.
        /// </summary>
        /// <value>
        ///     The break time.
        /// </value>
        public uint BreakTime { get; }

        /// <summary>
        ///     Gets the channel.
        /// </summary>
        /// <value>
        ///     The channel.
        /// </value>
        public uint Channel { get; }

        /// <summary>
        ///     Gets the stops.
        /// </summary>
        /// <value>
        ///     The stops.
        /// </value>
        public uint Stops { get; }

        #endregion
    }
}