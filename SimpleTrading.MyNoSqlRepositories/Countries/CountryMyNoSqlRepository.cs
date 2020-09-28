using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Common.Countries;

namespace SimpleTrading.MyNoSqlRepositories.Countries
{
    public class CountryMyNoSqlRepository : ICountryRepository
    {
        private readonly IMyNoSqlServerDataWriter<CountryMyNoSqlTableEntity> _table;

        public CountryMyNoSqlRepository(IMyNoSqlServerDataWriter<CountryMyNoSqlTableEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<ICountry>> GetAllAsync(string lang)
        {
            var pk = CountryMyNoSqlTableEntity.GeneratePartitionKey(lang);
            return await _table.GetAsync(pk);
        }

        public async Task UpdateAsync(ICountry country, string lang)
        {
            var entity = CountryMyNoSqlTableEntity.Create(country, lang);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}