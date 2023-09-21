namespace MyNoSqlRepositories.Abstraction.Trading.Swaps;

public interface ISwapScheduleReader
{
    IReadOnlyList<ISwapSchedule> GetAll();
    IReadOnlyList<ISwapSchedule> GetAll(string id);
}