using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.DataWriter;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InvestAmount
{
    public interface IInvestAmountMyNoSqlRepository
    {
        Task<IEnumerable<IInvestAmount>> GetAllAsync();

        Task UpdateAsync(IInvestAmount investAmount);
    }
    
    public class InvestAmountMyNoSqlRepository : IInvestAmountMyNoSqlRepository
    {
        private readonly MyNoSqlServerDataWriter<InvestAmountMyNoSqlTableEntity> _table;

        public InvestAmountMyNoSqlRepository(MyNoSqlServerDataWriter<InvestAmountMyNoSqlTableEntity> table)
        {
            _table = table;
        }

        public async Task<IEnumerable<IInvestAmount>> GetAllAsync()
        {
            var pk = InvestAmountMyNoSqlTableEntity.GeneratePartitionKey();
            return await _table.GetAsync(pk);
        }

        public async Task UpdateAsync(IInvestAmount investAmount)
        {
            var entity = InvestAmountMyNoSqlTableEntity.Create(investAmount);
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}