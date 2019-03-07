using System;

namespace PulseGenerator.Helper
{
    public interface IIsConnectedHandler
    {
        event EventHandler<bool> EventIsReached;

        void OnReached(bool e);
    }
}