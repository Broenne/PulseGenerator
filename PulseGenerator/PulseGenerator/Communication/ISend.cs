namespace PulseGenerator.Communication
{
    public interface ISend
    {
        void Do(uint channel, uint stops, uint stoptime);

        void Open(string comPort);

        void Close();
    }
}