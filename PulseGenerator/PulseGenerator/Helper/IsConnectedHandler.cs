namespace PulseGenerator.Helper
{
    using System;
    using System.Windows;

    /// <summary>
    /// The is connected evnet handler.
    /// </summary>
    /// <seealso cref="PulseGenerator.Helper.IIsConnectedHandler" />
    public class IsConnectedHandler : IIsConnectedHandler
    {
        #region Events

        /// <summary>
        ///     Occurs when [node is reached].
        /// </summary>
        public event EventHandler<bool> EventIsReached;

        #endregion

        #region Public Methods

        /// <summary>
        /// Called when [reached].
        /// </summary>
        /// <param name="e">if set to <c>true</c> [e].</param>
        public virtual void OnReached(bool e)
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
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        #endregion
    }
}