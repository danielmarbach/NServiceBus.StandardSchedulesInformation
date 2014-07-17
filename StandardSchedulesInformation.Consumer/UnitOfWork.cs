using System;
using System.Runtime.Remoting.Messaging;
using NServiceBus.Pipeline;
using NServiceBus.Pipeline.Contexts;
using NServiceBus.UnitOfWork;
using Raven.Client;

namespace StandardSchedulesInformation.Consumer
{
    public class UnitOfWork : IManageUnitsOfWork
    {
        private readonly IDocumentSession session;

        public UnitOfWork(IDocumentSession session)
        {
            this.session = session;
        }

        public void Begin()
        {
            // Can be left empty with RavenDB
        }

        public void End(Exception ex = null)
        {
            if (ex != null)
            {
                return;
            }

            this.session.SaveChanges();
        }
    }

    //// Future API possibilities
    ////public class UnitOfWorkBehavior : IBehavior<ReceivePhysicalMessageContext>
    ////{
    ////    public void Invoke(ReceivePhysicalMessageContext context, Action next)
    ////    {
    ////        using (var session = context.Builder.Build<IDocumentSession>())
    ////        {
    ////            next();

    ////            session.SaveChanges();
    ////        }
    ////    }
    ////}

    ////public class UnitOfWorkOverride : PipelineOverride
    ////{
    ////    public override void Override(BehaviorList<ReceivePhysicalMessageContext> behaviorList)
    ////    {
    ////        behaviorList.Replace<NServiceBus.UnitOfWork.UnitOfWorkBehavior, UnitOfWorkBehavior>();
    ////    }
    ////}
}