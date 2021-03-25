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
        public string CakeFtdId { get; set; }
        public string CakeDepositId { get; set; }
        public string CakeTradeId { get; set; }
        public string CakeStatusId { get; set; }

        public static BrandMyNoSqlEntity Create(IBrand src)
        {
            return new BrandMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                BaseDomain = src.BaseDomain,
                CakeRegistrationId = src.CakeRegistrationId,
                CakeFtdId = src.CakeFtdId,
                CakeDepositId = src.CakeDepositId,
                CakeTradeId = src.CakeTradeId,
                CakeStatusId = src.CakeStatusId
            };
        }
    }
}