using System.Collections.Generic;
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
        
        public IEnumerable<IPlatform> Get()
        {
            return _reader.Get();
        }

        public IEnumerable<IPlatform> Get(string brandId)
        {
            var pk = PlatformMyNoSqlEntity.GeneratePartitionKey(brandId);
            return _reader.Get(pk);
        }

        public IPlatform GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IPlatform Get(string brandId, PlatformTypes platformType)
        {
            var pk = PlatformMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = PlatformMyNoSqlEntity.GenerateRowKey(platformType);
            return _reader.Get(pk, rk);
        }
    }
}