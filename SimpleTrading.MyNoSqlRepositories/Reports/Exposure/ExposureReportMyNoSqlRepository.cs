using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Reports.Exposure;

namespace SimpleTrading.MyNoSqlRepositories.Reports.Exposure
{
    public class ExposureReportMyNoSqlRepository : IExposureReportRepository
    {
        private readonly IMyNoSqlServerDataWriter<InstrumentExposureMyNoSqlEntity> _table;

        public ExposureReportMyNoSqlRepository(IMyNoSqlServerDataWriter<InstrumentExposureMyNoSqlEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public async Task<IEnumerable<IExposure>> GetAsync(bool isInternal)
        {
            var partitionKey = InstrumentExposureMyNoSqlEntity.GeneratePartitionKey(isInternal);
            return await _table.GetAsync(partitionKey);
        }

        public async Task<IExposure> GetByIdAsync(bool isInternal, string instrumentId)
        {
            var partitionKey = InstrumentExposureMyNoSqlEntity.GeneratePartitionKey(isInternal);
            var rowKey = InstrumentExposureMyNoSqlEntity.GenerateRowKey(instrumentId);
            return await _table.GetAsync(partitionKey, rowKey);
        }

        public async Task SaveAsync(IExposure instrumentExposure)
        {
            var entity = InstrumentExposureMyNoSqlEntity.Create(instrumentExposure);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}