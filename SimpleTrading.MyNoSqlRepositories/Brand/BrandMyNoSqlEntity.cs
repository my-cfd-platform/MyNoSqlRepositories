using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Brand;

namespace SimpleTrading.MyNoSqlRepositories.Brand
{
    public class BrandMyNoSqlEntity : MyNoSqlDbEntity, IBrand
    {
        private const string Pk = "brand";
        
        public static string GeneratePartitionKey()
        {
            return Pk;
        }
        
        public static string GenerateRowKey(string id)
        {
            return id;
        }

        public string Id => RowKey;
        public string BaseDomain { get; set; }
        public string CakeRegistrationId { get; set; }

        public static BrandMyNoSqlEntity Create(IBrand src)
        {
            return new BrandMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                BaseDomain = src.BaseDomain,
                CakeRegistrationId = src.CakeRegistrationId
            };
        }
    }
}