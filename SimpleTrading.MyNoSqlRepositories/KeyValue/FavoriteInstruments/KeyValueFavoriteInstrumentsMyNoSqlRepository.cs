using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.FavoritesInstruments;

namespace SimpleTrading.MyNoSqlRepositories.KeyValue.FavoriteInstruments
{
    public class KeyValueFavoriteInstrumentsMyNoSqlRepository
    {
        private readonly IMyNoSqlServerDataWriter<KeyValueFavoriteInstrumentsMyNoSqlTableEntity> _table;

        public KeyValueFavoriteInstrumentsMyNoSqlRepository(IMyNoSqlServerDataWriter<KeyValueFavoriteInstrumentsMyNoSqlTableEntity> repository)
        {
            _table = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<KeyValueFavoriteInstrumentsMyNoSqlTableEntity>> GetAllAsync()
        {
            return await _table.GetAsync();
        }

        public async Task SaveAsync(string traderId, FavoriteInstrumentsTypes type, string value)
        {
            var entity = KeyValueFavoriteInstrumentsMyNoSqlTableEntity.Create(traderId, type, value);
            await _table.InsertOrReplaceAsync(entity);
        }
        
        public async Task<string> GetAsync(string traderId, FavoriteInstrumentsTypes type)
        {
            var partitionKey = KeyValueFavoriteInstrumentsMyNoSqlTableEntity.GeneratePartitionKey(traderId);
            var rowKey = KeyValueFavoriteInstrumentsMyNoSqlTableEntity.GenerateRowKey(type);

            var entity = await _table.GetAsync(partitionKey, rowKey);

            return entity?.Value;
        }
    }
}