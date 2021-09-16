using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataWriter;
using SimpleTrading.Abstraction.Markups;
using SimpleTrading.Abstraction.Markups.TradingGroupMarkupProfiles;

namespace SimpleTrading.MyNoSqlRepositories.Markups.TradingGroupsMarkups
{
    public class TradingGroupMarkupProfilesMyNoSqlRepository : ITradingGroupsMarkupProfilesRepository
    {
        private readonly IMyNoSqlServerDataWriter<MarkupProfileMyNoSqlTableEntity> _table;

        public TradingGroupMarkupProfilesMyNoSqlRepository(MyNoSqlServerDataWriter<MarkupProfileMyNoSqlTableEntity> table)
        {
            _table = table;
        }
        
        public async Task<IEnumerable<ITradingGroupMarkupProfile>> GetAllAsync()
        {
            var pk = MarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
            return await _table.GetAsync(pk);
        }

        public async Task UpdateAsync(ITradingGroupMarkupProfile markupProfile)
        {
            var entity = MarkupProfileMyNoSqlTableEntity.Create(markupProfile);
            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task<ITradingGroupMarkupProfile> GetById(string profileId)
        {
            var pk = MarkupProfileMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = MarkupProfileMyNoSqlTableEntity.GenerateRowKey(profileId);
            return await _table.GetAsync(pk, rk);
        }
    }
}