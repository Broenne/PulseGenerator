namespace PulseGenerator.Channel
{
    /// <summary>
    ///     Interaction logic for ChannelView.xaml
    /// </summary>
    public partial class ChannelView : IChannelView
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelView"/> class.
        /// </summary>
        /// <param name="vm">The vm.</param>
        public ChannelView(IChannelViewModel vm)
        {
            this.InitializeComponent();
            this.ViewModel = vm;
            this.DataContext = this.ViewModel;
        }


        private IChannelViewModel ViewModel { get; }
        #endregion

        public IChannelViewModel GetDataContext()
        {
            return this.ViewModel;
        }
    }
}