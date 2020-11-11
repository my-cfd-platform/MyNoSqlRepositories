using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Reports.Exposure;

namespace SimpleTrading.MyNoSqlRepositories.Reports.Exposure
{
    public class ExposureReportMyNoSqlReader : IExposureReportReader
    {
        private readonly IMyNoSqlServerDataReader<InstrumentExposureMyNoSqlEntity> _readRepository;

        public ExposureReportMyNoSqlReader(IMyNoSqlServerDataReader<InstrumentExposureMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }

        public IReadOnlyList<IExposure> Get(bool isInternal)
        {
            var partitionKey = InstrumentExposureMyNoSqlEntity.GeneratePartitionKey(isInternal);
            return _readRepository.Get(partitionKey);
        }

        public IExposure GetById(bool isInternal, string instrumentId)
        {
            var partitionKey = InstrumentExposureMyNoSqlEntity.GeneratePartitionKey(isInternal);
            var rowKey = InstrumentExposureMyNoSqlEntity.GenerateRowKey(instrumentId);
            return _readRepository.Get(partitionKey, rowKey);
        }
    }
}