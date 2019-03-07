﻿namespace PulseGenerator.Communication
{
    using System;
    using System.IO.Ports;

    using PulseGenerator.Helper;

    public class Send : ISend
    {
        #region Properties
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Send"/> class.
        /// </summary>
        /// <param name="isConnectedHandler">The is connected handler.</param>
        public Send(IIsConnectedHandler isConnectedHandler)
        {
            this.IsConnectedHandler = isConnectedHandler;
        }

        /// <summary>
        ///     Gets the is connected handler.
        /// </summary>
        /// <value>
        ///     The is connected handler.
        /// </value>
        public IIsConnectedHandler IsConnectedHandler { get; }

        private SerialPort SerialPort { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            try
            {
                this.SerialPort.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Does the specified channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <param name="stops">The stops.</param>
        /// <param name="stoptime">The stoptime.</param>
        public void Do(uint channel, uint stops, uint stoptime)
        {
            try
            {
                this.SerialPort.WriteLine($"{channel};{stops};{stoptime}");
                Console.WriteLine($"Send action channel:{channel} Stops:{stops} stoptime:{stoptime}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Opens the specified COM port.
        /// </summary>
        /// <param name="comPort">The COM port.</param>
        public void Open(string comPort)
        {
            try
            {
                this.SerialPort = new SerialPort();
                this.SerialPort.BaudRate = 115200;
                this.SerialPort.PortName = comPort;
                this.SerialPort.Close();
                this.SerialPort.Open();
                this.SerialPort.ReadTimeout = 200;

                this.IsConnectedHandler.OnReached(this.SerialPort.IsOpen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}