using System;
using System.Collections.Generic;

namespace SimpleTrading.MyNoSqlRepositories.Swaps
{
    public static class SwapScheduleMappers
    {
        
        private static readonly Dictionary<char, DayOfWeek> _mapperDayOfWeek = new Dictionary<char, DayOfWeek>
        {
            ['0'] = DayOfWeek.Sunday,
            ['1'] = DayOfWeek.Monday,
            ['2'] = DayOfWeek.Tuesday,
            ['3'] = DayOfWeek.Wednesday,
            ['4'] = DayOfWeek.Thursday,
            ['5'] = DayOfWeek.Friday,
            ['6'] = DayOfWeek.Saturday,
        };
        
        
        public static string SwapMomentToString(DayOfWeek dayOfWeek, string time)
        {
            return (int) dayOfWeek + time;
        }

        public static DayOfWeek GetDayOfWeekFromRowKey(this string rowKey)
        {
            return _mapperDayOfWeek[rowKey[0]];
        }
        
        public static string GetTimeFromRowKey(this string rowKey)
        {
            return rowKey.Substring(1, rowKey.Length-1);
        }
    }
}