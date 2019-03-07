namespace PulseGenerator
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>s
    public partial class App : Application
    {
        #region Properties

        /// <summary>
        ///     Gets the OSCI BOOTSTRAPPER.
        /// </summary>
        /// <value>
        ///     The OSCI BOOTSTRAPPER.
        /// </value>
        public PulseGeneratorBootstrapper PulseGeneratorBootstrapper { get; private set; }

        #endregion

        #region Protected Methods

        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                this.PulseGeneratorBootstrapper = new PulseGeneratorBootstrapper();
                this.PulseGeneratorBootstrapper.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                // throw;
            }
        }

        #endregion

        #region Private Methods

        private void ApplicationExit(object sender, ExitEventArgs e)
        {
            try
            {
                this.PulseGeneratorBootstrapper.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                // throw;
            }
        }

        #endregion
    }
}