using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseGenerator.Communication
{

    public class ReadEventHandler : IReadEventHandler
    {

        #region Events

        /// <summary>
        ///     Occurs when [node is reached].
        /// </summary>
        public event EventHandler<ReadArgumentsArgs> EventIsReached;

        #endregion

        #region Properties


        #endregion

        #region Public Methods


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
