using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.BidAsk;

namespace SimpleTrading.MyNoSqlRepositories.BidAsk
{
    public class PriceChangeWriteRepository : IPriceChangeWriter
    {
        private readonly IMyNoSqlServerDataWriter<PriceChangeMyNoSqlEntity> _table;

        public PriceChangeWriteRepository(IMyNoSqlServerDataWriter<PriceChangeMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task SaveAsync(IEnumerable<IPriceChange> changes)
        {
            var entities = changes.Select(PriceChangeMyNoSqlEntity.Create);
            await _table.BulkInsertOrReplaceAsync(entities.ToArray());
        }
    }
}