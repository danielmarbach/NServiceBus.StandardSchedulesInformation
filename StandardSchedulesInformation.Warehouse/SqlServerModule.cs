using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Ninject.Modules;
using NServiceBus.ObjectBuilder.Ninject;

namespace StandardSchedulesInformation.Warehouse
{
    public class SqlServerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDbConnection>()
                .ToMethod(
                    ctx => new SqlConnection(ConfigurationManager.ConnectionStrings["LegacyDB"].ConnectionString))
                .InUnitOfWorkScope()
                .OnActivation(connection => connection.Open());
        }
    }
}