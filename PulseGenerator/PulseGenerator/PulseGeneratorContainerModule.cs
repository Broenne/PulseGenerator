namespace PulseGenerator
{
    using System.Reflection;

    using Autofac;

    using PulseGenerator.Helper;

    using Module = Autofac.Module;

    /// <summary>
    /// </summary>
    /// <seealso cref="Autofac.Module" />
    public class PulseGeneratorContainerModule : Module
    {
        #region Protected Methods

        /// <summary>Override to add registrations to the container.</summary>
        /// <param name="builder">
        ///     The builder through which components can be
        ///     registered.
        /// </param>
        /// <remarks>Note that the ContainerBuilder parameter is unique to this module.</remarks>
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess).AsImplementedInterfaces();

            builder.RegisterType<IsConnectedHandler>().As<IIsConnectedHandler>().SingleInstance();
        }

        #endregion
    }
}