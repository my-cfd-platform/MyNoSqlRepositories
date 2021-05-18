using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.MyNoSqlRepositories.Engine;

namespace SimpleTrading.MyNoSqlRepositories.Cache.AccountsCache
{
    public class AccountCacheNoSqlReader
    {
        private readonly IMyNoSqlServerDataReader<EnginePersistenceQueueItemMyNoSqlModel> _reader;

        public AccountCacheNoSqlReader(IMyNoSqlServerDataReader<EnginePersistenceQueueItemMyNoSqlModel> reader)
        {
            _reader = reader;
        }

        public IReadOnlyList<EnginePersistenceQueueItemMyNoSqlModel> Get(string accountId)
        {
            var pk = EnginePersistenceQueueItemMyNoSqlModel.GeneratePartitionKey(accountId);

            return _reader.Get(pk);
        }

        public EnginePersistenceQueueItemMyNoSqlModel Get(string accountId, DateTime dateTime)
        {
            var pk = EnginePersistenceQueueItemMyNoSqlModel.GeneratePartitionKey(accountId);
            var rk = EnginePersistenceQueueItemMyNoSqlModel.GenerateRowKey(dateTime);

            return _reader.Get(pk, rk);
        }

        public void BindEventSubscribers(Action<IReadOnlyList<EnginePersistenceQueueItemMyNoSqlModel>> updateCallback,
            Action<IReadOnlyList<EnginePersistenceQueueItemMyNoSqlModel>> deleteCallback)
        {
            _reader.SubscribeToUpdateEvents(updateCallback, deleteCallback);
        }
    }
}