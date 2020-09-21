using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Languages;

namespace SimpleTrading.MyNoSqlRepositories.Languages
{
    public class LanguageMyNoSqlRepository : ILanguageRepository
    {
        private readonly IMyNoSqlServerDataWriter<LanguageMyNoSqlEntity> _table;

        public LanguageMyNoSqlRepository(IMyNoSqlServerDataWriter<LanguageMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task<IEnumerable<ILanguage>> GetAsync()
        {
            return await _table.GetAsync();
        }

        public async Task<ILanguage> GetAsync(string langId)
        {
            var pk = LanguageMyNoSqlEntity.GeneratePartitionKey(langId);
            var rk = LanguageMyNoSqlEntity.GenerateRowKey();
            
            return await _table.GetAsync(pk, rk);
        }

        public async Task SaveOrUpdateAsync(string langId)
        {
            var entity = LanguageMyNoSqlEntity.Create(langId);

            await _table.InsertOrReplaceAsync(entity);
        }
    }
}