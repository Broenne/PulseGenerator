namespace PulseGenerator.InitData
{
    using System.Collections.Generic;

    /// <summary>
    ///     The load service interface.
    /// </summary>
    public interface ILoad
    {
        #region Public Methods

        /// <summary>
        ///     Does this instance.
        /// </summary>
        /// <returns>Return the list.</returns>
        IReadOnlyList<ChannelInfo> Do();

        #endregion
    }
    
}