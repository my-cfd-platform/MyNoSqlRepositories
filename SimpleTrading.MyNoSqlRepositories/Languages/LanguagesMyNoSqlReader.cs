using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Languages;

namespace SimpleTrading.MyNoSqlRepositories.Languages
{
    public class LanguageMyNoSqlReader : ILanguageReader
    {
        private readonly IMyNoSqlServerDataReader<LanguageMyNoSqlEntity> _reader;

        public LanguageMyNoSqlReader(IMyNoSqlServerDataReader<LanguageMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public IEnumerable<ILanguage> Get()
        {
            return _reader.Get();
        }

        public ILanguage Get(string langId)
        {
            var pk = LanguageMyNoSqlEntity.GeneratePartitionKey(langId);
            var rk = LanguageMyNoSqlEntity.GenerateRowKey();
            
            return _reader.Get(pk, rk);
        }
    }
}