using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Common.Images;
using SimpleTrading.Abstraction.Trading.InstrumentsAvatar;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsAvatar
{
    public class TradingInstrumentAvatarMyNoSqlEntity : MyNoSqlEntity, ITradingInstrumentsAvatar
    {
        public static string GeneratePartitionKey(string id)
        {
            return id;
        }

        public static string GenerateRowKey(ImageTypes imageType)
        {
            return imageType.ToString();
        }
        
        public string Id => PartitionKey;

        public string Avatar { get; set; }

        public static TradingInstrumentAvatarMyNoSqlEntity Create(ITradingInstrumentsAvatar src, ImageTypes type)
        {
            return new TradingInstrumentAvatarMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(src.Id),
                RowKey = GenerateRowKey(type),
                Avatar = src.Avatar
            };
        }
    }
}