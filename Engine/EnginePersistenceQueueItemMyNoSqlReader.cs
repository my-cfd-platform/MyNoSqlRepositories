using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Engine;

public class EnginePersistenceQueueItemMyNoSqlReader
{
    private readonly IMyNoSqlServerDataReader<EnginePersistenceQueueItemMyNoSqlModel> _reader;

    public EnginePersistenceQueueItemMyNoSqlReader(IMyNoSqlServerDataReader<EnginePersistenceQueueItemMyNoSqlModel> reader)
    {
        _reader = reader;
    }
        
    public IReadOnlyList<EnginePersistenceQueueItemMyNoSqlModel> Get(string accountId)
    {
        var pk = EnginePersistenceQueueItemMyNoSqlModel.GeneratePartitionKey(accountId);

        return _reader.Get(pk);
    }
        
    public EnginePersistenceQueueItemMyNoSqlModel Get(string accountId, DateTime dateTime)
    {
        var pk = EnginePersistenceQueueItemMyNoSqlModel.GeneratePartitionKey(accountId);
        var rk = EnginePersistenceQueueItemMyNoSqlModel.GenerateRowKey(dateTime);

        return _reader.Get(pk, rk);
    }
}