using System.Collections.Generic;
using System.Linq;
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
        
        public IEnumerable<IBrand> Get()
        {
            return _reader.Get();
        }

        public string GetId(string brandId)
        {
            var brands = _reader.Get();

            var brand = brands.FirstOrDefault(x => x.Id.Contains(brandId));

            return brand != null ? brand.Id : string.Empty;
        }

        public IBrand Get(string brandId)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = BrandMyNoSqlEntity.GenerateRowKey();
            
            return _reader.Get(pk, rk);
        }
    }
}