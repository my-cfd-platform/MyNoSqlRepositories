using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Positions;
using SimpleTrading.Abstraction.Caches.PendingOrders;

namespace SimpleTrading.MyNoSqlRepositories.Cache.PendingOrders
{
    public class PendingOrdersNoSqlWriter : IPendingOrdersWriter
    {
        private readonly IMyNoSqlServerDataWriter<PendingOrderNoSqlEntity> _table;

        public PendingOrdersNoSqlWriter(IMyNoSqlServerDataWriter<PendingOrderNoSqlEntity> table)
        {
            _table = table;
        }

        public async ValueTask Delete(string accountId, string orderId)
        {
            var pk = PendingOrderNoSqlEntity.GeneratePartitionKey(accountId);
            var rk = PendingOrderNoSqlEntity.GeneratePartitionKey(orderId);
            await _table.DeleteAsync(pk, rk);
        }
        
        public async ValueTask BulkInsertOrReplace(IEnumerable<ITradeOrder> src)
        {
            await _table.BulkInsertOrReplaceAsync(src.Select(PendingOrderNoSqlEntity.Create).ToArray());
        }

        public async ValueTask UpdateTraderPendingOrder(string accountId, IEnumerable<ITradeOrder> src)
        {
            await _table.CleanAndBulkInsertAsync(accountId, src.Select(PendingOrderNoSqlEntity.Create).ToArray());
        }
    } 
}