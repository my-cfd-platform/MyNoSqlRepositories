using System;
using System.Collections.Generic;
using MyNoSqlServer.TcpClient.ReadRepository;
using SimpleTrading.Abstraction.Trading.FavoritesInstruments;

namespace SimpleTrading.MyNoSqlRepositories.Trading.FavoritesInstruments
{
    public class FavoriteInstrumentsMyNoSqlReadCache : IFavoriteInstrumentsReader
    {
        private readonly IMyNoSqlReadRepository<FavoriteInstrumentMyNoSqlEntity> _readRepository;

        public FavoriteInstrumentsMyNoSqlReadCache(IMyNoSqlReadRepository<FavoriteInstrumentMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }

        public IEnumerable<IFavoriteInstrument> GetAll(FavoriteInstrumentsTypes type)
        {
            var pk = FavoriteInstrumentMyNoSqlEntity.GeneratePartitionKey(type);
            return _readRepository.Get(pk);
        }
    }
}