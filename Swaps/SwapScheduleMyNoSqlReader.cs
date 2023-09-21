using MyNoSqlRepositories.Abstraction.Trading.Swaps;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Swaps;

public class SwapScheduleMyNoSqlReader : ISwapScheduleReader
{
    private readonly IMyNoSqlServerDataReader<SwapScheduleMyNoSqlEntity> _readRepository;

    public SwapScheduleMyNoSqlReader(IMyNoSqlServerDataReader<SwapScheduleMyNoSqlEntity> readRepository)
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