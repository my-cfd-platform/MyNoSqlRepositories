using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataWriter;
using SimpleTrading.Abstraction.Platform;
using SimpleTrading.Abstraction.Platforms;

namespace SimpleTrading.MyNoSqlRepositories.Platform
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly IMyNoSqlServerDataWriter<PlatformMyNoSqlEntity> _table;

        public PlatformRepository(MyNoSqlServerDataWriter<PlatformMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task<IEnumerable<IPlatform>> GetAsync()
        {
            return await _table.GetAsync();
        }

        public async Task<IEnumerable<IPlatform>> GetByBrand(string brandId)
        {
            var pk = PlatformMyNoSqlEntity.GeneratePartitionKey(brandId);
            
            return await _table.GetAsync(pk);
        }

        public async Task<IPlatform> Get(string brandId, PlatformTypes platformType)
        {
            var pk = PlatformMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = PlatformMyNoSqlEntity.GenerateRowKey(platformType);

            return await _table.GetAsync(pk, rk);
        }

        public async Task AddOrUpdate(IPlatform platform)
        {
            await _table.InsertOrReplaceAsync(PlatformMyNoSqlEntity.Create(platform));
        }

        public async Task DeleteAsync(string brandId, PlatformTypes platformType)
        {
            var pk = PlatformMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = PlatformMyNoSqlEntity.GenerateRowKey(platformType);
            
            await _table.DeleteAsync(pk, rk);
        }
    }
}