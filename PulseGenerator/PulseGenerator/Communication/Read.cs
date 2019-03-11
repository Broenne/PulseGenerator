namespace PulseGenerator.Communication
{
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The service for read serial.
    /// </summary>
    /// <seealso cref="PulseGenerator.Communication.IRead" />
    public class Read : IRead
    {
        private CancellationTokenSource cancelToken;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Read"/> class.
        /// </summary>
        /// <param name="readEventHandler">The read event handler.</param>
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
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
                                        var readArguments = this.BuildArguments(line);

                                        if (readArguments != null)
                                        {
                                            this.ReadEventHandler.OnReached(readArguments);
                                        }
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
                this.cancelToken?.Cancel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private ReadArgumentsArgs BuildArguments(string line)
        {
            var splittedLine = line.Split(';');
            ReadArgumentsArgs readArguments = null;
            if (splittedLine.Length.Equals(3))
            {
                var channelAsString = splittedLine[0];

                channelAsString = channelAsString.Replace("$SetPu", string.Empty);

                var stopsAsString = splittedLine[1];
                var breakTimeAsString = splittedLine[2];

                var channel = Convert.ToUInt32(channelAsString);
                var stops = Convert.ToUInt32(stopsAsString);
                var breakTime = Convert.ToUInt32(breakTimeAsString);

                readArguments = new ReadArgumentsArgs(channel, stops, breakTime);
            }
            else
            {
                Console.WriteLine("Ignore while wrong string");
            }

            return readArguments;
        }

        #endregion
    }
}