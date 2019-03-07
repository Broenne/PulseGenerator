using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseGenerator.Helper
{
    using System.Windows;

    public class IsConnectedHandler : IIsConnectedHandler
    {

        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="CanIsConnectedEventHandler" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public IsConnectedHandler()
        {
        }

        #endregion

        #region Events

        /// <summary>
        ///     Occurs when [node is reached].
        /// </summary>
        public event EventHandler<bool> EventIsReached;

        #endregion

        #region Properties


        #endregion

        #region Public Methods

       
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
