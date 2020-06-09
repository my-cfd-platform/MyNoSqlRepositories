using System;
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

        public async Task SaveAsync(IActivePositionsSnapshot snapshot)
        {
            var entity = ReportActivePositionMyNoSqlEntity.Create(snapshot);

            await _table.InsertOrReplaceAsync(entity);
        }
    }
}