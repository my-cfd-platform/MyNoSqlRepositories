namespace MyNoSqlRepositories.Abstraction.Trading.Instruments;

public interface ITradingInstrumentDayOff
{
    DayOfWeek DowFrom { get; }
    TimeSpan TimeFrom { get; }
        
    DayOfWeek DowTo { get; }
    TimeSpan TimeTo { get; }
}


public class TradingInstrumentDayOff : ITradingInstrumentDayOff
{
    public DayOfWeek DowFrom { get; private set; }
    public TimeSpan TimeFrom { get; private set; }
    public DayOfWeek DowTo { get; private set; }
    public TimeSpan TimeTo { get; private set; }

    public static TradingInstrumentDayOff Create(DayOfWeek dowFrom, TimeSpan timeFrom, DayOfWeek dowTo, TimeSpan timeTo)
    {
        return new TradingInstrumentDayOff
        {
            DowFrom = dowFrom,
            TimeFrom = timeFrom,
            DowTo = dowTo,
            TimeTo = timeTo
        };
    }
}