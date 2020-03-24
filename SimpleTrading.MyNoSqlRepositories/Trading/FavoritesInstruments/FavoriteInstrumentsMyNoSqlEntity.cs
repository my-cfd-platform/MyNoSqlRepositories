using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Trading.FavoritesInstruments;

namespace SimpleTrading.MyNoSqlRepositories.Trading.FavoritesInstruments
{
    public class FavoriteInstrumentMyNoSqlEntity : MyNoSqlTableEntity, IFavoriteInstrument
    {
        public static string GeneratePartitionKey(FavoriteInstrumentsTypes types)
        {
            return types.ToString();
        }

        public static string GenerateRowKey(string rk)
        {
            return rk;
        }

        public string Id => RowKey;

        public FavoriteInstrumentsTypes Type { get; set; }

        public static FavoriteInstrumentMyNoSqlEntity Create(IFavoriteInstrument src)
        {
            return new FavoriteInstrumentMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(src.Type),
                RowKey = GenerateRowKey(src.Id),
                Type = src.Type
            };
        }
    }
}