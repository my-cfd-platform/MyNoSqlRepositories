using System.Collections.Generic;
using MyNoSqlClient.ReadRepository;
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

        public IReadOnlyList<ICountry> Get()
        {
            var partitionKey = CountryMyNoSqlTableEntity.GeneratePartitionKey();

            return _readRepository.Get(partitionKey);
        }
    }
}