using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Brand;

namespace SimpleTrading.MyNoSqlRepositories.Brand
{
    public class BrandMyNoSqlEntity : MyNoSqlDbEntity, IBrand
    {
        public static string GeneratePartitionKey(string brandId)
        {
            return brandId;
        }
        
        public static string GenerateRowKey(string name)
        {
            return name;
        }
        
        public string Id => PartitionKey;
        
        public string Name => RowKey;

        public string Url { get; set; }
        
        public string LpUrl { get; set; }

        public static BrandMyNoSqlEntity Create(string brandId, string url, string name, string lpUrl)
        {
            return new BrandMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(brandId),
                RowKey = GenerateRowKey(name),
                Url = url,
                LpUrl = lpUrl
            };
        }
    }
}