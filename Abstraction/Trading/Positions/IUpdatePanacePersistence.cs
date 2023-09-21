using MyNoSqlRepositories.Abstraction.Accounts;
using MyNoSqlRepositories.Abstraction.Trading.BalanceOperations;

namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public interface IUpdateBalancePersistence
{
    ITradingAccount TradingAccount { get; }
    IBalanceOperation BalanceOperation { get; }
}