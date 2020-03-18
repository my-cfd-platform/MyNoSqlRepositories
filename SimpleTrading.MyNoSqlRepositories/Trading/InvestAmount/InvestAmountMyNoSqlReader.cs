using System.Collections.Generic;
using MyNoSqlServer.TcpClient.ReadRepository;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InvestAmount
{
    public interface IInvestAmountMyNoSqlReader
    {
        IEnumerable<IInvestAmount> GetAll();
    }
    
    public class InvestAmountMyNoSqlReader : IInvestAmountMyNoSqlReader
    {
        private readonly IMyNoSqlReadRepository<InvestAmountMyNoSqlTableEntity> _readRepository;

        public InvestAmountMyNoSqlReader(IMyNoSqlReadRepository<InvestAmountMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository;
        }
        
        public IEnumerable<IInvestAmount> GetAll()
        {
            var pk = InvestAmountMyNoSqlTableEntity.GeneratePartitionKey();
            return _readRepository.Get(pk);
        }
    }
}