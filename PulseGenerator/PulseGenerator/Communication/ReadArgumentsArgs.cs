using System;

namespace PulseGenerator.Communication
{
    public class ReadArgumentsArgs : EventArgs
    {
        public ReadArgumentsArgs(uint channel)
        {
            this.Channel = channel;
        }

        public uint Channel { get;  }
    }
}
