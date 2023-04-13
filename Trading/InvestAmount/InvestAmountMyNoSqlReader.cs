using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Trading.InvestAmount;

public interface IInvestAmountMyNoSqlReader
{
    IEnumerable<IInvestAmount> GetAll();
}
    
public class InvestAmountMyNoSqlReader : IInvestAmountMyNoSqlReader
{
    private readonly IMyNoSqlServerDataReader<InvestAmountMyNoSqlTableEntity> _readRepository;

    public InvestAmountMyNoSqlReader(IMyNoSqlServerDataReader<InvestAmountMyNoSqlTableEntity> readRepository)
    {
        _readRepository = readRepository;
    }
        
    public IEnumerable<IInvestAmount> GetAll()
    {
        var pk = InvestAmountMyNoSqlTableEntity.GeneratePartitionKey();
        return _readRepository.Get(pk);
    }
}