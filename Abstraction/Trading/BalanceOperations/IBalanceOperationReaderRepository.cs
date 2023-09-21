namespace MyNoSqlRepositories.Abstraction.Trading.BalanceOperations;

public interface IBalanceOperationReaderRepository
{
    Task<IEnumerable<IBalanceOperation>> GetBalanceOperationsAsync(string traderId, string accountId);

    Task<IEnumerable<IBalanceOperation>> GetBalanceOperationsByPeriodAsync(DateTime dateFrom, DateTime dateTo);
}