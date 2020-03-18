using System.Collections.Generic;
using MyNoSqlServer.TcpClient.ReadRepository;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace SimpleTrading.MyNoSqlRepositories.Swaps
{
    public class SwapProfileMyNoSqlReader : ISwapProfileReader
    {
        private readonly IMyNoSqlReadRepository<SwapProfileMyNoSqlEntity> _readRepository;

        public SwapProfileMyNoSqlReader(IMyNoSqlReadRepository<SwapProfileMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository;
        }


        public IReadOnlyList<ISwapProfile> GetAll()
        {
            return _readRepository.Get();
        }

        public IReadOnlyList<ISwapProfile> Get(string id)
        {
            var partitionKey = SwapProfileMyNoSqlEntity.GeneratePartitionKey(id);
            return _readRepository.Get(partitionKey);
        }
    }
}