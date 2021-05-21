using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Caches.ActiveOrders;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Cache.ActiveOrders
{
    public class ActiveOrdersCacheNoSqlWriter : IActiveOrdersWriter
    {
        private readonly IMyNoSqlServerDataWriter<ActiveOrderMyNoSqlEntity> _table;

        public ActiveOrdersCacheNoSqlWriter(IMyNoSqlServerDataWriter<ActiveOrderMyNoSqlEntity> table)
        {
            _table = table;
        }

        public async ValueTask BulkInsertOrReplace(IEnumerable<ITradeOrder> src)
        {
            await _table.BulkInsertOrReplaceAsync(src.Select(ActiveOrderMyNoSqlEntity.Create));
        }

        public async ValueTask UpdateTraderPendingOrder(string accountId, IEnumerable<ITradeOrder> src)
        {
            await _table.CleanAndBulkInsertAsync(accountId, src.Select(ActiveOrderMyNoSqlEntity.Create));
        }
    } 
}