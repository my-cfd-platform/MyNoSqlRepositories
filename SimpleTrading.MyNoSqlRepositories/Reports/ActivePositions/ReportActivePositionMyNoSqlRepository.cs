using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Reports.ActivePositions;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions
{
    public class ReportActivePositionMyNoSqlRepository : IReportActivePositionsRepository
    {
        private readonly IMyNoSqlServerDataWriter<ReportActivePositionMyNoSqlEntity> _table;

        public ReportActivePositionMyNoSqlRepository(IMyNoSqlServerDataWriter<ReportActivePositionMyNoSqlEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public async Task<IEnumerable<IActivePositionsSnapshot>> GetAsync()
        {
            var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();

            return await _table.GetAsync(pk);
        }

        public async Task<IEnumerable<IActivePositionsSnapshot>> GetAsync(string accountId)
        {
            var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();
            var rk = ReportActivePositionMyNoSqlEntity.GenerateRowKey(accountId);

            return await _table.GetAsync(pk);        
        }

        public async Task SaveAsync(IActivePositionsSnapshot snapshot)
        {
            var entity = ReportActivePositionMyNoSqlEntity.Create(snapshot);

            await _table.InsertOrReplaceAsync(entity);
        }
    }
}