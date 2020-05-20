using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Common.Images;
using SimpleTrading.Abstraction.Trading.InstrumentsAvatar;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsAvatar
{
    public class TradingInstrumentMyNoSqlReadCache : ITradingInstrumentsAvatarCache
    {
        private readonly IMyNoSqlServerDataReader<TradingInstrumentAvatarMyNoSqlEntity> _readRepository;

        public TradingInstrumentMyNoSqlReadCache(IMyNoSqlServerDataReader<TradingInstrumentAvatarMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }

        public ITradingInstrumentsAvatar Get(string id, ImageTypes imageType)
        {
            var pk = TradingInstrumentAvatarMyNoSqlEntity.GeneratePartitionKey(id);
            var rk = TradingInstrumentAvatarMyNoSqlEntity.GenerateRowKey(imageType);

            return _readRepository.Get(pk, rk);
        }
    }
}