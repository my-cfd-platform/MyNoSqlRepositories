using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.FavoritesInstruments;

namespace SimpleTrading.MyNoSqlRepositories.KeyValue.FavoriteInstruments
{
    public class KeyValueFavoriteInstrumentsMyNoSqlTableEntity : MyNoSqlDbEntity
    {
        public static string GeneratePartitionKey(string traderId)
        {
            return traderId;
        }

        public static string GenerateRowKey(FavoriteInstrumentsTypes type)
        {
            return type.ToString();
        }

        public string Value { get; set; }
        
        public bool IsModified { get; set; }

        public static KeyValueFavoriteInstrumentsMyNoSqlTableEntity Create(string traderId, FavoriteInstrumentsTypes type, string value)
        {
            return new KeyValueFavoriteInstrumentsMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(traderId),
                RowKey = GenerateRowKey(type),
                Value = value,
                IsModified = false
            };
        }
    }
}