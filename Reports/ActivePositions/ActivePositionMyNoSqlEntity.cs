using MyNoSqlRepositories.Abstraction.Reports.ActivePositions;
using MyNoSqlRepositories.Abstraction.Trading.Positions;
using MyNoSqlRepositories.Reports.ActivePositions.TradeOrder;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Reports.ActivePositions;

public class ReportActivePositionMyNoSqlEntity : MyNoSqlDbEntity, IActivePositionsSnapshot
{
    public static string GeneratePartitionKey()
    {
        return "activepos";
    }
        
    public static string GenerateRowKey(string accountId)
    {
        return accountId;
    }
        
    public string AccountId => RowKey;

    public string TraderId { get; set; }
        
    public DateTime DateTime { get; set; }
        
    public List<TradeOrderReportEntity> ActivePositions { get; set; }

    IEnumerable<ITradeOrder> IActivePositionsSnapshot.ActivePositions => ActivePositions;

    public static ReportActivePositionMyNoSqlEntity Create(IActivePositionsSnapshot src)
    {
        return new ReportActivePositionMyNoSqlEntity
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(src.AccountId),
            TraderId = src.TraderId,
            DateTime = src.DateTime,
            ActivePositions = src.ActivePositions?.Select(TradeOrderReportEntity.Create).ToList()
        };
    }
}