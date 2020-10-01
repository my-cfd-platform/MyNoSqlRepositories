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
        
        public static string GenerateRowKey()
        {
            return "br";
        }
        
        public string Id => PartitionKey;
        
        public string Url { get; set; }
        
        public string Name { get; set; }

        public static BrandMyNoSqlEntity Create(string brandId, string url, string name)
        {
            return new BrandMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(brandId),
                Url = url,
                Name = name,
                RowKey = GenerateRowKey()
            };
        }
    }
}