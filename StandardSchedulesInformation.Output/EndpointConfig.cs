using Ninject;
using Raven.Client.Linq;
using Raven.Client.Linq.Indexing;

namespace StandardSchedulesInformation.Output
{
    using NServiceBus;

    /*
        This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
        can be found here: http://particular.net/articles/the-nservicebus-host
    */
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            var kernel = new StandardKernel();
            kernel.Load(this.GetType().Assembly);

            Configure.With().NinjectBuilder(kernel);
        }
    }
}
