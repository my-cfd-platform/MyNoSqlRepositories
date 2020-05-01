using MyNoSqlServer.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps
{
    public class InstrumentSourcesMapsMyNoSqlReader
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
    }
}