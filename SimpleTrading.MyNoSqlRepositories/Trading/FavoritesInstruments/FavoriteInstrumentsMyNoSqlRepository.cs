using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Trading.FavoritesInstruments;

namespace SimpleTrading.MyNoSqlRepositories.Trading.FavoritesInstruments
{
    public class FavoriteInstrumentsMyNoSqlRepository : IFavoriteInstrumentsRepository
    {
        private readonly IMyNoSqlServerClient<FavoriteInstrumentMyNoSqlEntity> _table;

        public FavoriteInstrumentsMyNoSqlRepository(IMyNoSqlServerClient<FavoriteInstrumentMyNoSqlEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }
        
        public async Task<IEnumerable<IFavoriteInstrument>> GetAsync(FavoriteInstrumentsTypes type)
        {
            var pk = FavoriteInstrumentMyNoSqlEntity.GeneratePartitionKey(type);
            return await _table.GetAsync(pk);
        }

        public async Task AddOrUpdateAsync(IFavoriteInstrument defaultValue)
        {
            var entity = FavoriteInstrumentMyNoSqlEntity.Create(defaultValue);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}