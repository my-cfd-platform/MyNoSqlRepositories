using System;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Payments.Abstractions.DepositRestrictions;

namespace SimpleTrading.MyNoSqlRepositories.Deposits
{
    public class DepositRestrictionsNoSqlRepository : IDepositRestrictionsRepository
    {
        private readonly IMyNoSqlServerDataWriter<DepositRestrictionNoSqlEntity> _table;

        public DepositRestrictionsNoSqlRepository(IMyNoSqlServerDataWriter<DepositRestrictionNoSqlEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }
        
        public async Task<IDepositRestriction> GetAsync(string traderId)
        {
            var pk = DepositRestrictionNoSqlEntity.GeneratePartitionKey();
            var rk = DepositRestrictionNoSqlEntity.GenerateRowKey(traderId);           
            
            return await _table.GetAsync(pk, rk);
        }
        
        public async Task AddOrUpdateAsync(IDepositRestriction model)
        {
            var entity = new DepositRestrictionNoSqlEntity(model);
            await _table.InsertOrReplaceAsync(entity);
        }
        
        public async Task DeleteAsync(string traderId)
        {
            var pk = DepositRestrictionNoSqlEntity.GeneratePartitionKey();
            var rk = DepositRestrictionNoSqlEntity.GenerateRowKey(traderId);
            
            await _table.DeleteAsync(pk, rk);
        }
    }
}