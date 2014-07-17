using Ninject;
using Ninject.Modules;
using NServiceBus.ObjectBuilder.Ninject;
using NServiceBus.UnitOfWork;
using Raven.Client;
using Raven.Client.Document;

namespace StandardSchedulesInformation.Consumer
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
                    store.ConnectionStringName = "RavenDB";
                    store.Initialize();
                });

            this.Bind<IDocumentSession>().ToMethod(ctx => ctx.Kernel.Get<IDocumentStore>().OpenSession()).InUnitOfWorkScope();
            this.Bind<IManageUnitsOfWork>().To<UnitOfWork>();
        }
    }
}