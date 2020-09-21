using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Languages;

namespace SimpleTrading.MyNoSqlRepositories.Languages
{
    public class LanguageMyNoSqlEntity : MyNoSqlDbEntity, ILanguage
    {
        public static string GeneratePartitionKey(string langId)
        {
            return langId;
        }
        
        public static string GenerateRowKey()
        {
            return "lan";
        }
        
        public string Id => PartitionKey;

        public static LanguageMyNoSqlEntity Create(string langId)
        {
            return new LanguageMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(langId),
                RowKey = GenerateRowKey()
            };
        }
    }
}