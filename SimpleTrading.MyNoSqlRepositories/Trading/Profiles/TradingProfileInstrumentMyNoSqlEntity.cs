using System.Collections.Generic;
using System.Linq;
using MyNoSqlClient;
using SimpleTrading.Abstraction.Trading.Profiles;

namespace SimpleTrading.MyNoSqlRepositories.Trading.Profiles
{
public class TradingProfileInstrumentMyNoSqlEntity : ITradingProfileInstrument
    {
        public string Id { get; set; }
        public double MinOperationVolume { get; set; }
        public double MaxOperationVolume { get; set; }
        public double MaxPositionVolume { get; set; }
        public double SwapLong { get; set; }
        public double SwapShort { get; set; }
        public int OpenPositionMinDelayMs { get; set; }
        public int OpenPositionMaxDelayMs { get; set; }
        public bool TpSlippage { get; set; }
        public bool SlSlippage { get; set; }
        public bool OpenPositionSlippage { get; set; }
        public int[] Leverages { get; set; }

        public static TradingProfileInstrumentMyNoSqlEntity Create(ITradingProfileInstrument src)
        {
            return new TradingProfileInstrumentMyNoSqlEntity
            {
                Id = src.Id,
                SwapLong = src.SwapLong,
                SwapShort = src.SwapShort,
                MaxOperationVolume = src.MaxOperationVolume,
                MaxPositionVolume = src.MaxPositionVolume,
                MinOperationVolume = src.MinOperationVolume,
                Leverages = src.Leverages,
                SlSlippage = src.SlSlippage,
                TpSlippage = src.TpSlippage,
                OpenPositionSlippage = src.OpenPositionSlippage,
                OpenPositionMaxDelayMs = src.OpenPositionMaxDelayMs,
                OpenPositionMinDelayMs = src.OpenPositionMinDelayMs
                
            };
        }
    }


    public class TradingProfileMyNoSqlEntity : MyNoSqlTableEntity, ITradingProfile
    {

        public static string GeneratePartitionKey()
        {
            return "profile";
        }

        public static string GenerateRowKey(string id)
        {
            return id;
        }

        public string Id => RowKey;
        public double MarginCallPercent { get; set; }
        public double StopOutPercent { get; set; }

        IEnumerable<ITradingProfileInstrument> ITradingProfile.Instruments => Instruments;
        public List<TradingProfileInstrumentMyNoSqlEntity> Instruments { get; set; }


        public static TradingProfileMyNoSqlEntity Create(ITradingProfile src)
        {
            return new TradingProfileMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                MarginCallPercent = src.MarginCallPercent,
                StopOutPercent = src.StopOutPercent,
                Instruments = src.Instruments.Select(TradingProfileInstrumentMyNoSqlEntity.Create).ToList()
            };
        }
        
    }
}