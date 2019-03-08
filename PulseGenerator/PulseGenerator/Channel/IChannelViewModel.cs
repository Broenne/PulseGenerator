namespace PulseGenerator.Channel
{
    using System.Collections.Generic;

    /// <summary>
    ///     The channel view model.
    /// </summary>
    public interface IChannelViewModel
    {
        #region Public Methods

        /// <summary>
        ///     Gets the info.
        /// </summary>
        /// <returns>Return a prepared list.</returns>
        IReadOnlyList<string> GetInfos();

        #endregion
    }
}