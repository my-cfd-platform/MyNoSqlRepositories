using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Brand;

namespace SimpleTrading.MyNoSqlRepositories.Brand
{
    public class BrandMyNoSqlRepository : IBrandRepository
    {
        private readonly IMyNoSqlServerDataWriter<BrandMyNoSqlEntity> _table;

        public BrandMyNoSqlRepository(IMyNoSqlServerDataWriter<BrandMyNoSqlEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<IBrand>> GetAsync()
        {
            return await _table.GetAsync();
        }

        public async Task<IBrand> GetAsync(string brandId, string name)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = BrandMyNoSqlEntity.GenerateRowKey(name);
            
            return await _table.GetAsync(pk, rk);
        }

        public async Task SaveOrUpdateAsync(string brandId, string url, string name, string lpUrl)
        {
            var entity = BrandMyNoSqlEntity.Create(brandId, url, name, lpUrl);
            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task DeleteAsync(string brandId, string name)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = BrandMyNoSqlEntity.GenerateRowKey(name);

            await _table.DeleteAsync(pk, rk);
        }
    }
}