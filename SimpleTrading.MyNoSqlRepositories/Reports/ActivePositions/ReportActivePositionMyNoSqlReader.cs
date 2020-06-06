using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Reports.ActivePositions;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions
{
    public class ReportActivePositionMyNoSqlReader : IActivePositionsReader
    {
        private readonly IMyNoSqlServerDataReader<ReportActivePositionMyNoSqlEntity> _readRepository;

        public ReportActivePositionMyNoSqlReader(IMyNoSqlServerDataReader<ReportActivePositionMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }

        public IReadOnlyList<ITradeOrder> Get()
        {
            var pk = ReportActivePositionMyNoSqlEntity.GeneratePartitionKey();
            return _readRepository.Get(pk);
        }
    }
}