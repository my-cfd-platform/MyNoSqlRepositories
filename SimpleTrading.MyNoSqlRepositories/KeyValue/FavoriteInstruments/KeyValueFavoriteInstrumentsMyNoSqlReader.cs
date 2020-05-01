using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.FavoritesInstruments;

namespace SimpleTrading.MyNoSqlRepositories.KeyValue.FavoriteInstruments
{
    public class KeyValueFavoriteInstrumentsMyNoSqlReader
    {
        private readonly IMyNoSqlServerDataReader<KeyValueFavoriteInstrumentsMyNoSqlTableEntity> _readRepository;

        public KeyValueFavoriteInstrumentsMyNoSqlReader(IMyNoSqlServerDataReader<KeyValueFavoriteInstrumentsMyNoSqlTableEntity> repository)
        {
            _readRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public KeyValueFavoriteInstrumentsMyNoSqlTableEntity Get(string traderId, FavoriteInstrumentsTypes type)
        {
            var partitionKey = KeyValueFavoriteInstrumentsMyNoSqlTableEntity.GeneratePartitionKey(traderId);
            var rowKey = KeyValueFavoriteInstrumentsMyNoSqlTableEntity.GenerateRowKey(type);

            return _readRepository.Get(partitionKey, rowKey);
        }
    }
}