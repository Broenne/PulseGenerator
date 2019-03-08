namespace PulseGenerator.Communication
{
    /// <summary>
    /// The interface for send.
    /// </summary>
    public interface ISend
    {
        /// <summary>
        /// Does the specified channel.
        /// </summary>
        /// <param name="channel">The channel info.</param>
        /// <param name="stops">The stops in period.</param>
        /// <param name="stoptime">The stop time.</param>
        void Do(uint channel, uint stops, uint stoptime);

        /// <summary>
        /// Opens the specified COM port.
        /// </summary>
        /// <param name="comPort">The COM port.</param>
        void Open(string comPort);

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();
    }
}