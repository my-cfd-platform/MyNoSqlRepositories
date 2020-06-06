using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Reports.ActivePositions;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions
{
    public class ReportActivePositionMyNoSqlRepository : IReportActivePositionsRepository
    {
        private readonly IMyNoSqlServerDataWriter<ReportActivePositionMyNoSqlEntity> _table;

        public ReportActivePositionMyNoSqlRepository(IMyNoSqlServerDataWriter<ReportActivePositionMyNoSqlEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public async Task<IEnumerable<ITradeOrder>> GetAllAsync()
        {
            var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();

            return await _table.GetAsync(pk);
        }

        public async Task SaveAsync(IEnumerable<ITradeOrder> orders)
        {
            var myNoSqlEntities = orders.Select(ReportActivePositionMyNoSqlEntity.Create);
            await _table.BulkInsertOrReplaceAsync(myNoSqlEntities);
        }
    }
}