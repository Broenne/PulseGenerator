namespace PulseGenerator.Communication
{
    using System;

    /// <summary>
    ///     The read event handler.
    /// </summary>
    /// <seealso cref="PulseGenerator.Communication.IReadEventHandler" />
    public class ReadEventHandler : IReadEventHandler
    {
        #region Events

        /// <summary>
        ///     Occurs when [node is reached].
        /// </summary>
        public event EventHandler<ReadArgumentsArgs> EventIsReached;

        #endregion

        #region Public Methods

        /// <summary>
        /// Called when [reached].
        /// </summary>
        /// <param name="e">The event argument.</param>
        public virtual void OnReached(ReadArgumentsArgs e)
        {
            try
            {
                if (this.EventIsReached == null)
                {
                    return;
                }

                this.EventIsReached.Invoke(this, e);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        #endregion
    }
}