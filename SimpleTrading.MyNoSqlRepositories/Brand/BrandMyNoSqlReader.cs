using System.Collections.Generic;
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

            foreach (var brand in brands)
            {
                if (brandId.Contains(brand.Id))
                    return brand.Id;
            }
            
            return string.Empty;
        }

        public string GetUrl(string brandId)
        {
            var brands = _reader.Get();

            foreach (var brand in brands)
            {
                if (brandId.Contains(brand.Id))
                    return brand.Url;
            }
            
            return string.Empty;
        }

        public IBrand Get(string brandId)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = BrandMyNoSqlEntity.GenerateRowKey();
            
            return _reader.Get(pk, rk);
        }
    }
}