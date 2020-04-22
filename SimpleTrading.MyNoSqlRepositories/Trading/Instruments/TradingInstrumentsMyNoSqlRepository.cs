using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Common.Images;
using SimpleTrading.Abstraction.Trading.Instruments;

namespace SimpleTrading.MyNoSqlRepositories.Trading.Instruments
{
    public class TradingInstrumentsMyNoSqlRepository : ITradingInstrumentsRepository
    {
        private readonly IMyNoSqlServerClient<TradingInstrumentMyNoSqlEntity> _table;

        public TradingInstrumentsMyNoSqlRepository(IMyNoSqlServerClient<TradingInstrumentMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task<IEnumerable<ITradingInstrument>> GetAllAsync()
        {
            var partitionKey = TradingInstrumentMyNoSqlEntity.GeneratePartitionKey();
            return await _table.GetAsync(partitionKey);
        }

        public async Task UpdateAsync(ITradingInstrument item)
        {
            var entity = TradingInstrumentMyNoSqlEntity.Create(item);
            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task AddOrUpdateAvatarAsync(string id, string avatar, ImageTypes type)
        {
            var pk = TradingInstrumentMyNoSqlEntity.GeneratePartitionKey();
            var rk = TradingInstrumentMyNoSqlEntity.GenerateRowKey(id);
            
            var entity = await _table.GetAsync(pk, rk);
            
            if (entity == null)
                return;

            if (type == ImageTypes.PNG)
                entity.AvatarPng = avatar;

            if (type == ImageTypes.SVG)
                entity.AvatarSvg = avatar;
            
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}