namespace PulseGenerator.Communication
{
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Threading.Tasks;

    public class Read : IRead
    {
        private CancellationTokenSource cancelToken;

        #region Constructor

        public Read(IReadEventHandler readEventHandler)
        {
            this.ReadEventHandler = readEventHandler;
        }

        #endregion

        #region Properties

        private IReadEventHandler ReadEventHandler { get; }

        private SerialPort SerialPort { get; set; }

        #endregion

        #region Public Methods

        public void Dispose()
        {
            try
            {
                this.Stop();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///     Permanents the asynchronous.
        /// </summary>
        /// <param name="serialPort">The serial port.</param>
        /// <returns>Return the task.</returns>
        public async Task PermanentAsync(SerialPort serialPort)
        {
            try
            {
                this.SerialPort = serialPort;

                this.cancelToken = new CancellationTokenSource();

                await Task.Run(
                    () =>
                        {
                            while (!this.cancelToken.IsCancellationRequested)
                            {
                                if (this.SerialPort != null && this.SerialPort.IsOpen)
                                {
                                    try
                                    {
                                        var line = this.SerialPort.ReadLine();

                                        // todo mb: mappen
                                        this.ReadEventHandler.OnReached(new ReadArgumentsArgs(2));
                                    }
                                    catch (TimeoutException)
                                    {
                                        // ignoress
                                    }
                                }
                            }
                        },
                    this.cancelToken.Token);

                this.SerialPort?.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///     Stops this instance.
        /// </summary>
        public void Stop()
        {
            try
            {
                this.cancelToken.Cancel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}