namespace PulseGenerator.Channel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;

    using Prism.Mvvm;

    using PulseGenerator.Communication;
    using PulseGenerator.Helper;

    /// <summary>
    /// The channel view model.
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
        /// <param name="send">The send info.</param>
        public ChannelViewModel(IIsConnectedHandler isConnectedHandler, ISend send, IReadEventHandler readEventHandler)
        {
            isConnectedHandler.EventIsReached += this.IsConnectedHandler_EventIsReached;

            var list = new List<ChannelDataForView>();

            for (uint i = 0; i < 8; i++)
            {
                // todo mb: factory
                list.Add(new ChannelDataForView(i, send, readEventHandler));
            }

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
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetProperty(ref this.isEnabled, value);
        }

        #endregion

        #region Private Methods

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