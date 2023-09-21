using MyNoSqlRepositories.Abstraction.Markups;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;

namespace MyNoSqlRepositories.Markups;

public class MarkupProfilesMyNoSqlReader : IMarkupProfilesReader
{
    private readonly IMyNoSqlServerDataReader<MarkupProfileMyNoSqlTableEntity> _readRepository;

    public MarkupProfilesMyNoSqlReader(
        MyNoSqlReadRepository<MarkupProfileMyNoSqlTableEntity> readRepository)
    {
        _readRepository = readRepository;
    }

    public IMarkupProfile Get(string profileId)
    {
        var partitionKey = MarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
        var rowKey = MarkupProfileMyNoSqlTableEntity.GenerateRowKey(profileId);

        return _readRepository.Get(partitionKey, rowKey);
    }
}