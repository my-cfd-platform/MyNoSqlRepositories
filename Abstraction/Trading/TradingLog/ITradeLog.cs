namespace MyNoSqlRepositories.Abstraction.Trading.TradingLog;

public interface ITradeLog
{
    DateTime DateTime { get; }
        
    string TraderId { get; }
        
    string AccountId { get; }
        
    string ProcessId { get; }

    string Component { get; }
        
    string JsonData { get; }
        
    string Message { get; }
        
    string ObjectId { get; }
        
}