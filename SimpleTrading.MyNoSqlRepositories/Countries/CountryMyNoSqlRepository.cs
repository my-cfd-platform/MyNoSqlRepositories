using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction;
using SimpleTrading.Abstraction.Common.Countries;

namespace SimpleTrading.MyNoSqlRepositories.Countries
{
    public class CountryMyNoSqlRepository : ICountryRepository
    {
        private readonly IMyNoSqlServerClient<CountryMyNoSqlTableEntity> _table;

        public CountryMyNoSqlRepository(IMyNoSqlServerClient<CountryMyNoSqlTableEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<ICountry>> GetAllAsync(Languages lang)
        {
            var pk = CountryMyNoSqlTableEntity.GeneratePartitionKey(lang);
            return await _table.GetAsync(pk);
        }

        public async Task UpdateAsync(ICountry country, Languages lang)
        {
            var entity = CountryMyNoSqlTableEntity.Create(country, lang);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}