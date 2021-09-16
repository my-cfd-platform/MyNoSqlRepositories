using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;
using SimpleTrading.Abstraction.Markups;
using SimpleTrading.Abstraction.Markups.TradingGroupMarkupProfiles;

namespace SimpleTrading.MyNoSqlRepositories.Markups.TradingGroupsMarkups
{
    public class TradingGroupMarkupProfilesMyNoSqlReader : ITradingGroupsMarkupProfilesReader
    {
        private readonly IMyNoSqlServerDataReader<MarkupProfileMyNoSqlTableEntity> _readRepository;

        public TradingGroupMarkupProfilesMyNoSqlReader(
            MyNoSqlReadRepository<MarkupProfileMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository;
        }

        public ITradingGroupMarkupProfile Get(string profileId)
        {
            var partitionKey = MarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = MarkupProfileMyNoSqlTableEntity.GenerateRowKey(profileId);

            return _readRepository.Get(partitionKey, rowKey);
        }
    }
}