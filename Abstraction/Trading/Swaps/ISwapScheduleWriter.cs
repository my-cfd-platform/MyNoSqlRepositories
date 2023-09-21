namespace MyNoSqlRepositories.Abstraction.Trading.Swaps;

public interface ISwapScheduleWriter
{
    Task<IReadOnlyList<ISwapSchedule>> GetAllAsync();
    Task<IReadOnlyList<ISwapSchedule>> GetAllAsync(string id);

    Task AddOrUpdateAsync(ISwapSchedule itm);
    Task DeleteAsync(string scheduleId, DayOfWeek dayOfWeek, TimeSpan time);
}