using MyNoSqlServer.TcpClient.ReadRepository;
using SimpleTrading.Abstraction.Markups;
using SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps;

namespace SimpleTrading.MyNoSqlRepositories.Markups
{
    public class MarkupProfilesMyNoSqlReader : IMarkupProfilesReader
    {
        private readonly IMyNoSqlReadRepository<MarkupProfileMyNoSqlTableEntity> _readRepository;

        public MarkupProfilesMyNoSqlReader(
            IMyNoSqlReadRepository<MarkupProfileMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository;
        }

        public IMarkupProfile Get(string profileId)
        {
            var partitionKey = InstrumentSourcesMapsMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = InstrumentSourcesMapsMyNoSqlTableEntity.GenerateRowKey(profileId);

            return _readRepository.Get(partitionKey, rowKey);
        }
    }
}