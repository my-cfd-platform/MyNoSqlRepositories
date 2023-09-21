namespace MyNoSqlRepositories.Abstraction.Accounts;

public interface ITradingAccountsReaderRepository
{
    Task<IEnumerable<ITradingAccount>> GetTradingAccountsAsync(string traderId);
    Task<ITradingAccount> GetTradingAccountAsync(string traderId, string accountId);
    Task<IEnumerable<ITradingAccount>> GetTradingAccountsAsync();
}