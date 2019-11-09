using System;
using NUnit.Framework;
using SimpleTrading.Core.Instruments;
using SimpleTrading.MyNoSqlRepositories.Instruments;

namespace SimpleTrading.MyNoSqlRepositories.Tests
{

    public class TestDayOffEntity : ITradingInstrumentDayOff
    {
        public DayOfWeek DowFrom { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public DayOfWeek DowTo { get; set; }
        public TimeSpan TimeTo { get; set; }
    }


    public class TestsTradingInstrumentDayOffMyNoSqlEntity
    {


        [Test]
        public void TestToContractConversion()
        {

            var srcEntity = new TestDayOffEntity
            {
                DowFrom = DayOfWeek.Monday,
                DowTo = DayOfWeek.Friday,
                TimeFrom = TimeSpan.Parse("10:34:22"),
                TimeTo = TimeSpan.Parse("15:24:53"),

            };
            var entity = TradingInstrumentDayOffMyNoSqlEntity.Create(srcEntity) as ITradingInstrumentDayOff;
            
            
            Assert.AreEqual(srcEntity.DowFrom, entity.DowFrom);
            Assert.AreEqual(srcEntity.DowTo, entity.DowTo);
            
            Assert.AreEqual(srcEntity.TimeFrom, entity.TimeFrom);
            Assert.AreEqual(srcEntity.TimeTo, entity.TimeTo);
        }

    }

}