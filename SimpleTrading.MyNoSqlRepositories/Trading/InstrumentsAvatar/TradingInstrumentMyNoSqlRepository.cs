using System;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Common.Images;
using SimpleTrading.Abstraction.Trading.InstrumentsAvatar;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsAvatar
{
    public class TradingInstrumentMyNoSqlRepository : ITradingInstrumentsAvatarRepository
    {
        private readonly IMyNoSqlServerDataWriter<TradingInstrumentAvatarMyNoSqlEntity> _table;

        public TradingInstrumentMyNoSqlRepository(IMyNoSqlServerDataWriter<TradingInstrumentAvatarMyNoSqlEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public async Task UpdateAsync(string id, string avatar, ImageTypes imageType)
        {
            var entity = TradingInstrumentAvatarMyNoSqlEntity.Create(id, avatar, imageType);
            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task<ITradingInstrumentsAvatar> GetInstrumentsAvatarAsync(string id, ImageTypes imageType)
        {
            var pk = TradingInstrumentAvatarMyNoSqlEntity.GeneratePartitionKey(id);
            var rk = TradingInstrumentAvatarMyNoSqlEntity.GenerateRowKey(imageType);

            return await _table.GetAsync(pk, rk);
        }
    }
}