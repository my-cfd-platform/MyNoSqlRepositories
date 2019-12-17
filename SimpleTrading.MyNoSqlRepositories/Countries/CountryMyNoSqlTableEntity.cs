using MyNoSqlClient;
using SimpleTrading.Common.Abstraction.Countries;

namespace SimpleTrading.MyNoSqlRepositories.Countries
{
    public class CountryMyNoSqlTableEntity : MyNoSqlTableEntity, ICountry
    {
        public static string GeneratePartitionKey()
        {
            return "country";
        }

        public static string GenerateRowKey(string asset)
        {
            return asset;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Dial { get; set; }

        public string ArabicFormal { get; set; }

        public string ArabicShort { get; set; }

        public string ChineseFormal { get; set; }

        public string ChineseShort { get; set; }

        public string EnglishFormal { get; set; }

        public string EnglishShort { get; set; }

        public string FrenchFormal { get; set; }

        public string FrenchShort { get; set; }

        public string RussianFormal { get; set; }

        public string RussianShort { get; set; }

        public string SpanishFormal { get; set; }

        public string SpanishShort { get; set; }

        public static CountryMyNoSqlTableEntity Create(ICountry src)
        {
            return new CountryMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                Id = src.Id,
                Name = src.Name,
                Dial = src.Dial,
                ArabicFormal = src.ArabicFormal,
                ArabicShort = src.ArabicShort,
                ChineseFormal = src.ChineseFormal,
                ChineseShort = src.ChineseShort,
                EnglishFormal = src.EnglishFormal,
                EnglishShort = src.EnglishShort,
                FrenchFormal = src.FrenchFormal,
                FrenchShort = src.FrenchShort,
                RussianFormal = src.RussianFormal,
                RussianShort = src.RussianShort,
                SpanishFormal = src.SpanishFormal,
                SpanishShort = src.SpanishShort
            };
        }
    }
}