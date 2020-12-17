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

        public async Task<IBrand> GetAsync(string id)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey(); 
            var rk = BrandMyNoSqlEntity.GenerateRowKey(id); 
            
            return await _table.GetAsync(pk, rk);
        }

        public async Task SaveOrUpdateAsync(IBrand brand)
        {
            await _table.InsertOrReplaceAsync(BrandMyNoSqlEntity.Create(brand));
        }

        public async Task DeleteAsync(string id)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey();
            var rk = BrandMyNoSqlEntity.GenerateRowKey(id);
            
            await _table.DeleteAsync(pk, rk);
        }
    }
}