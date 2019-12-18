using System.Collections.Generic;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.Common;
using SimpleTrading.Common.Abstraction.Countries;

namespace SimpleTrading.MyNoSqlRepositories.Countries
{
    public class CountryMyNoSqlReader : ICountryReader
    {
        private readonly IMyNoSqlReadRepository<CountryMyNoSqlTableEntity> _readRepository;

        public CountryMyNoSqlReader(IMyNoSqlReadRepository<CountryMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository;
        }

        public IReadOnlyList<ICountry> Get(Languages lang)
        {
            var partitionKey = CountryMyNoSqlTableEntity.GeneratePartitionKey(lang);

            return _readRepository.Get(partitionKey);
        }
    }
}