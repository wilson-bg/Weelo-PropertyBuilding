using Autofac;
using System.Web.Mvc;
using System.Runtime.CompilerServices;
using Autofac.Integration.Mvc;

namespace Weelo.Core.Registers
{
    public class FactoryContext
    {
        /// <summary>
        /// The container
        /// </summary>
        private static IContainer container = null;

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container
        {
            get
            {
                if (container != null)
                {
                    return container;
                }
                else
                {
                    Initialize();
                    return container;
                }
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Initialize()
        {
            if (container == null)
            {
                var builder = new ContainerBuilder();
                
                var factory = new FactoryRegister();
                factory.Register(builder);
                container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }

    }
}
