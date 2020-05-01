using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction;
using SimpleTrading.Abstraction.Common.Countries;

namespace SimpleTrading.MyNoSqlRepositories.Countries
{
    public class CountryMyNoSqlReader : ICountryReader
    {
        private readonly IMyNoSqlServerDataReader<CountryMyNoSqlTableEntity> _readRepository;

        public CountryMyNoSqlReader(IMyNoSqlServerDataReader<CountryMyNoSqlTableEntity> readRepository)
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