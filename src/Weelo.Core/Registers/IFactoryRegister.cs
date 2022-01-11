using Autofac;

namespace Weelo.Core.Registers
{
    public interface IFactoryRegister
    {
        /// <summary>
        /// Registers the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        void Register(ContainerBuilder builder);
    }
}
