using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Brand;

namespace SimpleTrading.MyNoSqlRepositories.Brand
{
    public class BrandMyNoSqlReader : IBrandReader
    {
        private readonly IMyNoSqlServerDataReader<BrandMyNoSqlEntity> _reader;
        
        public BrandMyNoSqlReader(IMyNoSqlServerDataReader<BrandMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public async Task<IEnumerable<IBrand>> GetAsync()
        {
            return _reader.Get();
        }

        public async Task<IBrand> GetAsync(string id)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey();
            var rk = BrandMyNoSqlEntity.GenerateRowKey(id);

            return _reader.Get(pk, rk);
        }
    }
}