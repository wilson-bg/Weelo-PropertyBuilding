using Autofac;
using System;
using Weelo.Core.Interfaces;
using Weelo.Core.Services;

namespace Weelo.Core.Registers
{
    /// <summary>
    /// Factory Register
    /// </summary>
    /// <seealso cref="IFactoryRegister" />
    public class FactoryRegister : IFactoryRegister
    {
        /// <summary>
        /// Registers the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<OwnerService>()
                .As<IOwnerService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PropertyService>()
                .As<IPropertyService>()
                .InstancePerLifetimeScope();

        }
    }
}
