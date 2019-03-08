namespace PulseGenerator.InitData
{
    public class ChannelInfo
    {
        public ChannelInfo(uint channel, uint stops, uint stopTime)
        {
            this.Channel = channel;
            this.Stops = stops;
            this.StopTime = stopTime;
        }

        public uint Channel { get; }
        public uint Stops { get; }
        public uint StopTime { get; }
    }
    
}