namespace MyNoSqlRepositories.Abstraction.Trading.TradingLog;

public interface ITradeLogRepository
{
    ValueTask RegisterAsync(ITradeLog tradeLog);

    ValueTask<IReadOnlyList<ITradeLog>> Get(string traderId, string accountId, DateTime from, DateTime to);
}