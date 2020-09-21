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

        public static BrandMyNoSqlEntity Create(string brandId)
        {
            return new BrandMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(brandId),
                RowKey = GenerateRowKey()
            };
        }
    }
}