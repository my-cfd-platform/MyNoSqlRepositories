
using MyNoSqlServer.TcpClient.ReadRepository;

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
        
        public InstrumentSourcesMapsMyNoSqlTableEntity Get(string instrumentId)
        {
            var partitionKey = InstrumentSourcesMapsMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = InstrumentSourcesMapsMyNoSqlTableEntity.GenerateRowKey(instrumentId);

            return _readRepository.Get(partitionKey, rowKey);
        } 
    }
}