using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Platform;
using SimpleTrading.Abstraction.Platforms;

namespace SimpleTrading.MyNoSqlRepositories.Platform
{
    public class PlatformMyNoSqlReader : IPlatformReader
    {
        private readonly IMyNoSqlServerDataReader<PlatformMyNoSqlEntity> _reader;
        
        public PlatformMyNoSqlReader(IMyNoSqlServerDataReader<PlatformMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public async Task<IEnumerable<IPlatform>> GetAsync()
        {
            return _reader.Get();
        }

        public async Task<IEnumerable<IPlatform>> GetAsync(string brandId)
        {
            var pk = PlatformMyNoSqlEntity.GeneratePartitionKey(brandId);
            return _reader.Get(pk);
        }

        public async Task<IPlatform> GetAsync(string brandId, PlatformTypes platformType)
        {
            var pk = PlatformMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = PlatformMyNoSqlEntity.GenerateRowKey(platformType);
            return _reader.Get(pk, rk);
        }
    }
}