using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Instruments;
using SimpleTrading.Abstraction.Trading.Settings;

namespace MyNoSqlRepositories.Trading.Instruments;

public class InstrumentsMyNoSqlReadCache : IInstrumentsCache
{
    private readonly IMyNoSqlServerDataReader<TradingInstrumentMyNoSqlEntity> _readRepository;

    public InstrumentsMyNoSqlReadCache(IMyNoSqlServerDataReader<TradingInstrumentMyNoSqlEntity> readRepository)
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