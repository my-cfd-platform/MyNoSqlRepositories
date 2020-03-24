using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Trading;

namespace SimpleTrading.MyNoSqlRepositories.Trading.Profiles
{
    public class TradingGroupMyNoSqlEntity : MyNoSqlTableEntity, ITradingGroup
    {
        public static string GeneratePartitionKey()
        {
            return "group";
        }
        public static string GenerateRowKey(string profileId)
        {
            return profileId;
        }
        
        public string Id => RowKey;
        
        public string Name { get; set; }
        
        public string TradingProfileId { get; set; }
        
        public bool TradingDisabled { get; set; }

        public static TradingGroupMyNoSqlEntity Create(ITradingGroup src)
        {
            return new TradingGroupMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                Name = src.Name,
                TradingProfileId = src.TradingProfileId,
                TradingDisabled = src.TradingDisabled
            };
        } 
    }
}