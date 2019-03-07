namespace PulseGenerator.Communication
{
    using System;
    using System.IO.Ports;
    using System.Threading.Tasks;

    /// <summary>
    ///     The interface for read.
    /// </summary>
    public interface IRead : IDisposable
    {
        #region Public Methods

        /// <summary>
        /// Permanents the asynchronous.
        /// </summary>
        /// <param name="serialPort">The serial port.</param>
        /// <returns>Return the task.</returns>
        Task PermanentAsync(SerialPort serialPort);

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();

        #endregion
    }
}