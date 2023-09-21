namespace MyNoSqlRepositories.Abstraction.Trading.Instruments;

public interface ITradingInstrument
{
    string Id { get; }
    string Name { get; } 
    int Digits { get; }  
    string Base { get; } 
    string Quote { get; }
    double TickSize { get; }
    string SwapScheduleId { get; }
    string? GroupId { get; set; }
    string? SubGroupId { get; set; }
    int? Weight { get; set; }
    IEnumerable<ITradingInstrumentDayOff> DaysOff { get; }
    int? DayTimeout { get; set; }
    int? NightTimeout { get; set; }
    int? MarginCallPercent { get; set; }
    bool TradingDisabled { get; set; }
}