using System.Collections.Generic;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace SimpleTrading.MyNoSqlRepositories.Swaps
{
    public class SwapScheduleMyNoSqlReader : ISwapScheduleReader
    {
        private readonly IMyNoSqlReadRepository<SwapScheduleMyNoSqlEntity> _readRepository;

        public SwapScheduleMyNoSqlReader(IMyNoSqlReadRepository<SwapScheduleMyNoSqlEntity> readRepository)
        {
            _readRepository = readRepository;
        }
        
        public IReadOnlyList<ISwapSchedule> GetAll()
        {
            return _readRepository.Get();
        }

        public IReadOnlyList<ISwapSchedule> GetAll(string id)
        {
            return _readRepository.Get(id);
        }
    }
}