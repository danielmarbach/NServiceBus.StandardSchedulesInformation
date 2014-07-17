using System;
using System.Data;
using Dapper;
using StandardSchedulesInformation.Contracts;

namespace StandardSchedulesInformation.Warehouse
{
    public class AdHocSchedulesMessageModifier
    {
        private readonly IDbConnection connection;

        public AdHocSchedulesMessageModifier(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Modify(AdHocSchedulesMessage message)
        {
            this.connection.Execute("INSERT INTO Messages(at, flightidentifier) VALUES(@at,@flightidentifier)", 
                new { at = DateTimeOffset.Now, flightidentifier = message.FlightInformation.FlightIdentifier });
        }
    }
}