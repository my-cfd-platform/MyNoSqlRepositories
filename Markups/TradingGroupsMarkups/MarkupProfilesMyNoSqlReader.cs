using MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;

namespace MyNoSqlRepositories.Markups.TradingGroupsMarkups;

public class TradingGroupMarkupProfilesMyNoSqlReader : ITradingGroupsMarkupProfilesReader
{
    private readonly IMyNoSqlServerDataReader<TradingGroupMarkupProfileMyNoSqlTableEntity> _readRepository;

    public TradingGroupMarkupProfilesMyNoSqlReader(
        MyNoSqlReadRepository<TradingGroupMarkupProfileMyNoSqlTableEntity> readRepository)
    {
        _readRepository = readRepository;
    }

    public ITradingGroupMarkupProfile Get(string profileId)
    {
        var partitionKey = TradingGroupMarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
        var rowKey = TradingGroupMarkupProfileMyNoSqlTableEntity.GenerateRowKey(profileId);

        return _readRepository.Get(partitionKey, rowKey);
    }
}