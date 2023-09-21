namespace MyNoSqlRepositories.Abstraction.Trading.Swaps;

public interface ISwapSchedule
{
    string Id { get; }
    DayOfWeek DayOfWeek { get; }
    TimeSpan Time { get; }
    int Amount { get; }
}