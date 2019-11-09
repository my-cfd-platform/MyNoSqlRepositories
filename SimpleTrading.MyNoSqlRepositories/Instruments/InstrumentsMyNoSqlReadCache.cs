using System.Collections.Generic;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.Core.Instruments;

namespace SimpleTrading.MyNoSqlRepositories.Instruments
{
    public class InstrumentsMyNoSqlReadCache : IInstrumentsCache
    {
        private readonly IMyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity> _readRepository;

        public InstrumentsMyNoSqlReadCache(IMyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<ITradingInstrument> GetAll()
        {
            var partitionKey = TradingInstrumentMyNoSqlEntity.GeneratePartitionKey();
            return _readRepository.Get(partitionKey);
        }

        public ITradingInstrument Get(string id)
        {
            var partitionKey = TradingInstrumentMyNoSqlEntity.GeneratePartitionKey();
            var rowKey = TradingInstrumentMyNoSqlEntity.GenerateRowKey(id);
            return _readRepository.Get(partitionKey, rowKey);
        }

        public ITradingInstrument Get(string onePart, string otherPart)
        {
            var all = GetAll();
            foreach (var instr in all)
            {
                if (instr.Base == onePart && instr.Quote == otherPart)
                    return instr;

                if (instr.Quote == onePart && instr.Base == otherPart)
                    return instr;
            }

            return null;
        }
    }
}