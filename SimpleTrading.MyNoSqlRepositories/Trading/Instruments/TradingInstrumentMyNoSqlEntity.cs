using System.Collections.Generic;
using System.Linq;
using MyNoSqlClient;
using SimpleTrading.Abstraction.Trading.Settings;

namespace SimpleTrading.MyNoSqlRepositories.Trading.Instruments
{
    public class TradingInstrumentMyNoSqlEntity : MyNoSqlTableEntity, ITradingInstrument
    {

        public static string GeneratePartitionKey()
        {
            return "i";
        }

        public static string GenerateRowKey(string id)
        {
            return id;
        }

        public string Id => RowKey;
        public string Name { get; set; }
        public int Digits { get; set; }
        public string Base { get; set; }
        public string Quote { get; set; }
        public string TickSize { get; set; }

        IEnumerable<ITradingInstrumentDayOff> ITradingInstrument.DaysOff => DaysOff;
        public List<TradingInstrumentDayOffMyNoSqlEntity> DaysOff { get; set; }


        public static TradingInstrumentMyNoSqlEntity Create(ITradingInstrument src)
        {
            return new TradingInstrumentMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                Name = src.Name,
                Digits = src.Digits,
                Base = src.Base,
                Quote = src.Quote,
                TickSize = src.TickSize,
                DaysOff = src.DaysOff == null 
                    ? new List<TradingInstrumentDayOffMyNoSqlEntity>() :
                    src.DaysOff.Select(TradingInstrumentDayOffMyNoSqlEntity.Create).ToList()
            };
        }
    }
}