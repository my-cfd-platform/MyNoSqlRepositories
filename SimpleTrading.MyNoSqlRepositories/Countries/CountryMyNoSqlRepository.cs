using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlClient;
using SimpleTrading.Common.Abstraction.Countries;

namespace SimpleTrading.MyNoSqlRepositories.Countries
{
    public class CountryMyNoSqlRepository : ICountryRepository
    {
        private readonly IMyNoSqlServerClient<CountryMyNoSqlTableEntity> _table;

        public CountryMyNoSqlRepository(IMyNoSqlServerClient<CountryMyNoSqlTableEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<ICountry>> GetAllAsync()
        {
            var pk = CountryMyNoSqlTableEntity.GeneratePartitionKey();
            return await _table.GetAsync(pk);
        }

        public async Task UpdateAsync(ICountry country)
        {
            var entity = CountryMyNoSqlTableEntity.Create(country);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}