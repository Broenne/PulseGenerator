namespace PulseGenerator.Channel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    using Prism.Mvvm;

    using PulseGenerator.Communication;
    using PulseGenerator.Helper;
    using PulseGenerator.InitData;

    /// <summary>
    ///     The channel view model.
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    /// <seealso cref="PulseGenerator.Channel.IChannelViewModel" />
    public class ChannelViewModel : BindableBase, IChannelViewModel
    {
        private bool isEnabled;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelViewModel" /> class.
        /// </summary>
        /// <param name="isConnectedHandler">The is connected handler.</param>
        /// <param name="load">The load.</param>
        /// <param name="send">The send info.</param>
        /// <param name="readEventHandler">The read event handler.</param>
        public ChannelViewModel(IIsConnectedHandler isConnectedHandler, ILoad load, ISend send, IReadEventHandler readEventHandler)
        {
            isConnectedHandler.EventIsReached += this.IsConnectedHandler_EventIsReached;

            this.Load = load;

            var list = this.PrepareUi(send, readEventHandler);
            this.ChannelDataForViewList = new ObservableCollection<ChannelDataForView>(list);
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the times.
        /// </summary>
        /// <value>
        ///     The times.
        /// </value>
        public ObservableCollection<ChannelDataForView> ChannelDataForViewList { get; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetProperty(ref this.isEnabled, value);
        }

        private ILoad Load { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Gets the infos.
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<string> GetInfos()
        {
            try
            {
                var xxx = new List<string>();

                foreach (var item in this.ChannelDataForViewList)
                {
                    xxx.Add($"{item}");
                }

                return xxx;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private IList<ChannelDataForView> PrepareUi(ISend send, IReadEventHandler readEventHandler)
        {
            // todo mb: das ist eigentlich ein eigenr service
            var inits = this.Load.Do();

            var list = new List<ChannelDataForView>();

            for (uint i = 0; i < 8; i++)
            {
                var channel = i;
                uint stops = 10;
                uint stopTime = 20;

                var theChannelInfo = inits.FirstOrDefault(x => x.Channel.Equals(i));
                if (theChannelInfo != null)
                {
                    channel = theChannelInfo.Channel;
                    stops = theChannelInfo.Stops;
                    stopTime = theChannelInfo.StopTime;
                }

                // todo mb: factory
                list.Add(new ChannelDataForView(channel, stops, stopTime, send, readEventHandler));
            }

            return list;
        }

        private void IsConnectedHandler_EventIsReached(object sender, bool e)
        {
            try
            {
                this.IsEnabled = e;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}