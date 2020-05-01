using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace SimpleTrading.MyNoSqlRepositories.Swaps
{
    public class SwapProfileMyNoSqlReader : ISwapProfileReader
    {
        private readonly IMyNoSqlServerDataReader<SwapProfileMyNoSqlEntity> _readRepository;

        public SwapProfileMyNoSqlReader(IMyNoSqlServerDataReader<SwapProfileMyNoSqlEntity> readRepository)
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