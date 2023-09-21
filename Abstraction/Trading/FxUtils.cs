using MyNoSqlRepositories.Abstraction.BidAsk;
using MyNoSqlRepositories.Abstraction.Trading.Instruments;
using MyNoSqlRepositories.Abstraction.Trading.Positions;
using MyNoSqlRepositories.Abstraction.Trading.Profiles;

namespace MyNoSqlRepositories.Abstraction.Trading;

public static class FxBaseUtils
{
    private static readonly TimeSpan _morningTimeSpan = new TimeSpan(19, 0, 0);
    private static readonly TimeSpan _eveningTimeSpan = new TimeSpan(7, 0, 0);
        
    public static double GetOpenPrice(this IBidAsk bidAsk, PositionOperation type)
    {
        if (type == PositionOperation.Buy)
            return bidAsk.Ask;

        return bidAsk.Bid;
    }

    public static double GetClosePrice(this IBidAsk bidAsk, PositionOperation type)
    {
        if (type == PositionOperation.Buy)
            return bidAsk.Bid;

        return bidAsk.Ask;
    }
        
    public static double GetOpenPrice(this ITradeOrder tradeOrder)
    {
        return tradeOrder.OpenBidAsk.GetOpenPrice(tradeOrder.Operation);
    }
        
        
    public static double GetClosePrice(this ITradeOrder tradeOrder)
    {
        return tradeOrder.CloseBidAsk.GetClosePrice(tradeOrder.Operation);
    }
        
        
    public static TimeSpan GetTimeSpan(this DateTime dt)
    {
        return new TimeSpan(dt.Hour, dt.Minute, dt.Second);
    }

    public static bool IsDay(this DateTime dt)
    {
        return _morningTimeSpan <= dt.TimeOfDay && dt.TimeOfDay <= _eveningTimeSpan;
    }

    public static bool IsQuoteTimeout(this IBidAsk bidAsk, ITradingInstrument instrument, DateTime dateTime)
    {
        var isDayNow = IsDay(dateTime);

        return Math.Abs((dateTime - bidAsk.DateTime).TotalSeconds) >
               (isDayNow ? instrument.DayTimeout : instrument.NightTimeout);
    }
        
    private const int SecondsInDay = 60 * 60 * 24;

    private static int ToInt(this DayOfWeek dayOfWeek, TimeSpan timeSpan)
    {
        return (int)dayOfWeek * SecondsInDay + timeSpan.Hours * 3600 + timeSpan.Minutes * 60 + timeSpan.Seconds;
    }
        
    public static bool IsDayOff(this ITradingInstrumentDayOff dayOff, DayOfWeek dayOfWeek, TimeSpan timeSpan)
    {

        var now = dayOfWeek.ToInt(timeSpan);

        var from = dayOff.DowFrom.ToInt(dayOff.TimeFrom);

        var to = dayOff.DowTo.ToInt(dayOff.TimeTo);

        if (from < to)
            return from <= now && now <= to;

        return now >= from || now <= to;
    }

    public static bool IsDayOff(this ITradingInstrument instrument, DateTime dateTime)
    {
        var dow = dateTime.DayOfWeek;
        var time = dateTime.GetTimeSpan();

        return instrument.DaysOff.Any(dayOff => dayOff.IsDayOff(dow, time));
    }

    public static int GetRandomDelayMs(this ITradingProfileInstrument instrument)
    {
        var rand = new Random();

        return rand.Next(instrument.OpenPositionMinDelayMs, instrument.OpenPositionMaxDelayMs);
    }
}