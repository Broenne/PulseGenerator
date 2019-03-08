namespace PulseGenerator.Channel
{
    /// <summary>
    ///     Interaction logic for ChannelView.
    /// </summary>
    public partial class ChannelView : IChannelView
    {
        #region Constructor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChannelView" /> class.
        /// </summary>
        /// <param name="vm">The view model.</param>
        public ChannelView(IChannelViewModel vm)
        {
            this.InitializeComponent();
            this.ViewModel = vm;
            this.DataContext = this.ViewModel;
        }

        #endregion

        #region Properties

        private IChannelViewModel ViewModel { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Gets the data context.
        /// </summary>
        /// <returns>
        ///     Return the channel view model.
        /// </returns>
        public IChannelViewModel GetDataContext()
        {
            return this.ViewModel;
        }

        #endregion
    }
}