using System.IO.Ports;
using System.Threading.Tasks;

namespace PulseGenerator.Communication
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRead
    {

        Task PermanentAsync(SerialPort serialPort);

        void Stop();
    }
}