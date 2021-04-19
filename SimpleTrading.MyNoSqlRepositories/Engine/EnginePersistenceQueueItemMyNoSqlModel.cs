using System;
using MyNoSqlServer.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.Engine
{
    public class EnginePersistenceQueueItemMyNoSqlModel : MyNoSqlDbEntity
    {
        private const string DateFormat = "yyyy-MM-ddTHH:mm:ss.fffff";

        public static string GeneratePartitionKey(string accountId)
        {
            return accountId;
        }

        public static string GenerateRowKey(DateTime dateTime)
        {
            return DateTime.UtcNow.ToString(DateFormat);
        }

        public string AccountId => PartitionKey;
        public DateTime DateTime => DateTime.Parse(DateFormat);
        public object Data { get; set; }

        public T GetData<T>()
        {
            return (T) Data;
        }

        public static EnginePersistenceQueueItemMyNoSqlModel Create(string accountId, DateTime dateTime, object data)
        {
            return new EnginePersistenceQueueItemMyNoSqlModel
            {
                PartitionKey = GeneratePartitionKey(accountId),
                RowKey = GenerateRowKey(dateTime),
                Data = data
            };
        }
    }
}