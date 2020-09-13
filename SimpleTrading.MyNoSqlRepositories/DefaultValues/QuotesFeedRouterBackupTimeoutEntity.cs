using System;
using MyNoSqlServer.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class QuotesFeedRouterBackupTimeoutEntity : MyNoSqlDbEntity
    {
        public static string GeneratePartitionKey()
        {
            return "dv";
        }

        public static string GenerateRowKey()
        {
            return "QuotesFeedRouterBackupTimeout";
        }

        public TimeSpan Value { get; set; }
    }
}