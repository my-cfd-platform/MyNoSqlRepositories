namespace MyNoSqlRepositories.Abstraction.Trading.BalanceOperations;

public interface IBalanceOperation
{
    DateTime DateTime { get; }
        
    long Id { get; }
        
    string TraderId { get; }
        
    string AccountId { get; }
        
    double Delta { get; }
        
    string Comment { get; }
        
    BalanceUpdateOperationType OperationType { get; }
}