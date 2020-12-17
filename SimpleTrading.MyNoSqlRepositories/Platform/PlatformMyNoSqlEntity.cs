using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Platform;
using SimpleTrading.Abstraction.Platforms;

namespace SimpleTrading.MyNoSqlRepositories.Platform
{
    public class PlatformMyNoSqlEntity : MyNoSqlDbEntity, IPlatform
    {
        public static string GeneratePartitionKey(string brandId)
        {
            return brandId;
        }
        
        public static string GenerateRowKey(PlatformTypes type)
        {
            return type.ToString();
        }

        public string BrandId => PartitionKey;
        public PlatformTypes Platform => Enum.Parse<PlatformTypes>(RowKey);
        public string PlatformName { get; set;}
        public string BasePlatformUrl { get; set;}
        public string BaseAuthUrl { get; set;}
        public string BaseAutoLoginUrl { get; set;}

        public static PlatformMyNoSqlEntity Create(IPlatform src)
        {
            return new PlatformMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(src.BrandId),
                RowKey = GenerateRowKey(src.Platform),
                PlatformName = src.PlatformName,
                BasePlatformUrl = src.BasePlatformUrl,
                BaseAuthUrl = src.BaseAuthUrl,
                BaseAutoLoginUrl = src.BaseAutoLoginUrl
            };
        }
    }
}