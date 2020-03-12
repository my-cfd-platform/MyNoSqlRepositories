using MyNoSqlClient.ReadRepository;

namespace SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps
{
    public class InstrumentSourcesMapsMyNoSqlReader
    {
        private readonly IMyNoSqlReadRepository<InstrumentSourcesMapsMyNoSqlTableEntity> _readRepository;

        public InstrumentSourcesMapsMyNoSqlReader(
            IMyNoSqlReadRepository<InstrumentSourcesMapsMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository;
        }
        
        public InstrumentSourcesMapsMyNoSqlTableEntity Get(string instrumetId)
        {
            var partitionKey = InstrumentSourcesMapsMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = InstrumentSourcesMapsMyNoSqlTableEntity.GenerateRowKey(instrumetId);

            return _readRepository.Get(partitionKey, rowKey);
        } 
    }
}