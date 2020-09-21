using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction;
using SimpleTrading.Abstraction.Common.Countries;

namespace SimpleTrading.MyNoSqlRepositories.Countries
{
    public class CountryMyNoSqlTableEntity : MyNoSqlDbEntity, ICountry
    {
        public static string GeneratePartitionKey(string lang)
        {
            return lang;
        }

        public static string GenerateRowKey(string asset)
        {
            return asset;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Dial { get; set; }

        public static CountryMyNoSqlTableEntity Create(ICountry src, string lang)
        {
            return new CountryMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(lang),
                RowKey = GenerateRowKey(src.Id),
                Id = src.Id,
                Name = src.Name,
                Dial = src.Dial
            };
        }
    }
}