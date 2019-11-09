using System;
using System.Collections.Generic;
using SimpleTrading.Core.Instruments;

namespace SimpleTrading.MyNoSqlRepositories.Instruments
{
    public class TradingInstrumentDayOffMyNoSqlEntity : ITradingInstrumentDayOff
    {
        public DayOfWeek DowFrom { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public DayOfWeek DowTo { get; set; }
        public TimeSpan TimeTo { get; set; }


        public static TradingInstrumentDayOffMyNoSqlEntity Create(ITradingInstrumentDayOff instrumentDayOff)
        {
            return new TradingInstrumentDayOffMyNoSqlEntity
            {
                DowFrom = instrumentDayOff.DowFrom,
                TimeFrom = instrumentDayOff.TimeFrom,
                DowTo = instrumentDayOff.DowTo,
                TimeTo = instrumentDayOff.TimeTo
            };
        }
    }
    
    

}