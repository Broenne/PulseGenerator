namespace PulseGenerator.Communication
{
    using System;

    /// <summary>
    /// The read event handler.
    /// </summary>
    public interface IReadEventHandler
    {
        #region Events

        /// <summary>
        /// Occurs when [event is reached].
        /// </summary>
        event EventHandler<ReadArgumentsArgs> EventIsReached;

        #endregion

        #region Public Methods

        /// <summary>
        /// Called when [reached].
        /// </summary>
        /// <param name="e">The event argument.</param>
        void OnReached(ReadArgumentsArgs e);

        #endregion
    }
}