namespace PulseGenerator.Channel
{
    /// <summary>
    /// Tzhe channel view interface.
    /// </summary>
    public interface IChannelView
    {
        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <returns>Return the channel view model.</returns>
        IChannelViewModel GetDataContext();
    }
}