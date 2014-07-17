using Ninject;
using Ninject.Modules;
using NServiceBus.ObjectBuilder.Ninject;
using Raven.Client;
using Raven.Client.Document;

namespace StandardSchedulesInformation.Warehouse
{
    public class RavenDBModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDocumentStore>().To<DocumentStore>()
                .InSingletonScope()
                .OnActivation(store =>
                {
                    store.Conventions.FailoverBehavior = FailoverBehavior.AllowReadsFromSecondariesAndWritesToSecondaries;
                    store.Conventions.ShouldCacheRequest = url => true;
                    store.ConnectionStringName = "RavenDB";
                    store.Initialize();
                });

            this.Bind<IDocumentSession>().ToMethod(ctx => ctx.Kernel.Get<IDocumentStore>().OpenSession()).InUnitOfWorkScope();
        }
    }
}