using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PulseGenerator.Channel
{
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using System.Windows;

    using Prism.Mvvm;

    using PulseGenerator.Helper;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    /// <seealso cref="PulseGenerator.Channel.IChannelViewModel" />
    public class ChannelViewModel : BindableBase, IChannelViewModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelViewModel"/> class.
        /// </summary>
        public ChannelViewModel(IIsConnectedHandler isConnectedHandler)
        {
            isConnectedHandler.EventIsReached += IsConnectedHandler_EventIsReached;

            var list = new List<ChannelDataForView>();

            for (int i = 0; i < 8; i++)
            {
                list.Add(new ChannelDataForView(i.ToString()));
            }

            this.ChannelDataForViewList = new ObservableCollection<ChannelDataForView>(list);
        }


        private bool isEnabled;
        /// <summary>
        ///     Gets or sets the COM ports.
        /// </summary>
        /// <value>
        ///     The COM ports.
        /// </value>
        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetProperty(ref this.isEnabled, value);
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

        /// <summary>
        ///     Gets the times.
        /// </summary>
        /// <value>
        ///     The times.
        /// </value>
        public ObservableCollection<ChannelDataForView> ChannelDataForViewList { get; }

    }
}
