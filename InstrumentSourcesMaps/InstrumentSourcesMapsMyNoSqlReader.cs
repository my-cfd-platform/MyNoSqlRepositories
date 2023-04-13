using MyNoSqlServer.Abstractions;
using SimpleTrading.QuotesFeedRouter.Abstractions;

namespace MyNoSqlRepositories.InstrumentSourcesMaps;

public class InstrumentSourcesMapsMyNoSqlReader : IInstrumentSourceMapReader
{
    private readonly IMyNoSqlServerDataReader<InstrumentSourcesMapsMyNoSqlTableEntity> _readRepository;

    public InstrumentSourcesMapsMyNoSqlReader(
        IMyNoSqlServerDataReader<InstrumentSourcesMapsMyNoSqlTableEntity> readRepository)
    {
        _readRepository = readRepository;
    }
        
    public InstrumentSourcesMapsMyNoSqlTableEntity Get(string instrumentId)
    {
        var partitionKey = InstrumentSourcesMapsMyNoSqlTableEntity.GeneratePartitionKey();
        var rowKey = InstrumentSourcesMapsMyNoSqlTableEntity.GenerateRowKey(instrumentId);

        return _readRepository.Get(partitionKey, rowKey);
    }

    IQuoteFeedSource IInstrumentSourceMapReader.Get(string instrumentId)
    {
        return Get(instrumentId);
    }
}