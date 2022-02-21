using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Markups.TradingGroupMarkupProfiles;

namespace SimpleTrading.MyNoSqlRepositories.Markups.TradingGroupsMarkups
{
    public class TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity : MyNoSqlDbEntity, ITradingGroupMarkupProfileProperties
    {
        public static string GeneratePartitionKey()
        {
            return "mkp";
        }

        public static string GenerateRowKey(string asset)
        {
            return asset;
        }

        public string ProfileId => RowKey;

        public string Description { get; set; }

        public bool IsHidden { get; set; }

        public static TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity Create(ITradingGroupMarkupProfileProperties src)
        {
            return new TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.ProfileId),
                Description = src.Description,
                IsHidden = src.IsHidden,
            };
        }
    }
}