namespace PulseGenerator.Channel
{
    /// <summary>
    ///     Interaction logic for ChannelView.xaml
    /// </summary>
    public partial class ChannelView : IChannelView
    {
        #region Constructor

        public ChannelView(IChannelViewModel vm)
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        #endregion
    }
}