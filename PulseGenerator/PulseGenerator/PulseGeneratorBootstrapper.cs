﻿namespace PulseGenerator
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Threading;

    using Autofac;

    using Prism.Autofac;

    using PulseGenerator.Main;

    /// <summary>
    ///     The pulse generator boot STRAPPER.
    /// </summary>
    /// <seealso cref="Prism.Autofac.AutofacBootstrapper" />
    /// <seealso cref="System.IDisposable" />
    public class PulseGeneratorBootstrapper : AutofacBootstrapper, IDisposable
    {
        #region Public Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            try
            {
                Console.WriteLine("Dispose bootstrapper");
                this.Container?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        ///     Configures the container.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            try
            {
                base.ConfigureContainerBuilder(builder);

                builder.RegisterModule<PulseGeneratorContainerModule>();
                builder.RegisterType<MainWindow>().As<IMainWindow>().SingleInstance();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        ///     Creates the shell or main window of the application.
        /// </summary>
        /// <returns>
        ///     The shell of the application.
        /// </returns>
        /// <remarks>
        ///     If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        ///     <see cref="T:Microsoft.Practices.Prism.Bootstrapper" /> will attach the default
        ///     <see cref="T:Microsoft.Practices.Prism.Regions.IRegionManager" /> of
        ///     the application in its <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty" />
        ///     attached property
        ///     in order to be able to add regions by using the
        ///     <see cref="F:Microsoft.Practices.Prism.Regions.RegionManager.RegionNameProperty" />
        ///     attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            var window = this.Container.Resolve<IMainWindow>();

            return (MainWindow)window;
        }

        /// <summary>
        ///     Initializes the shell.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
        protected override void InitializeShell()
        {
            try
            {
                var curDis = Dispatcher.CurrentDispatcher;
                curDis.Thread.GetApartmentState();

                base.InitializeShell();

                Application.Current.MainWindow = (MainWindow)this.Shell;

                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.MinWidth = 0;
                    Application.Current.MainWindow.MinHeight = 0;
                    Application.Current.MainWindow.Show();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        #endregion
    }
}