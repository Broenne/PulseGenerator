namespace PulseGenerator
{
    using PulseGenerator.Main;

    /// <summary>
    ///     Interaction logic for MainWindow.
    /// </summary>
    public partial class MainWindow : IMainWindow
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="vm">The view model.</param>
        public MainWindow(IMainWindowViewModel vm)
        {
            this.InitializeComponent();
            this.DataContext = vm;
        }

        #endregion
    }
}