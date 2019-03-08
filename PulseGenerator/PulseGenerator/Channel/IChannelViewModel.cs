using System.Collections.ObjectModel;

namespace PulseGenerator.Channel
{
    using System.Collections.Generic;

    public interface IChannelViewModel
    {
        IReadOnlyList<string> GetInfos();
    }
}