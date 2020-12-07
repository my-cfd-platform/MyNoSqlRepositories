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

        public IBrand Get(string brandId, string name)
        {
            var pk = BrandMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = BrandMyNoSqlEntity.GenerateRowKey(name);

            return _reader.Get(pk, rk);
        }
    }
}