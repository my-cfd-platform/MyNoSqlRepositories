using System.Collections.Generic;
using System.Linq;
using MyNoSqlClient;
using SimpleTrading.Core.TradingGroups;

namespace SimpleTrading.MyNoSqlRepositories.TradingGroups
{

    public class InstrumentGroupInfoMyNoSqlEntity : IInstrumentGroupInfo
    {
        public string Id { get; set; }
        public double MinOperationVolume { get; set; }
        public double MaxOperationVolume { get; set; }
        public double MaxPositionVolume { get; set; }
        public double SwapLong { get; set; }
        public double SwapShort { get; set; }
        public double CommissionOpen { get; set; }
        public double CommissionClose { get; set; }

        public static InstrumentGroupInfoMyNoSqlEntity Create(IInstrumentGroupInfo src)
        {
            return new InstrumentGroupInfoMyNoSqlEntity
            {
                Id = src.Id,
                CommissionClose = src.CommissionClose,
                CommissionOpen = src.CommissionOpen,
                SwapLong = src.SwapLong,
                SwapShort = src.SwapShort,
                MaxOperationVolume = src.MaxOperationVolume,
                MaxPositionVolume = src.MaxPositionVolume,
                MinOperationVolume = src.MinOperationVolume
            };
        }
    }


    public class TradingGroupMyNoSqlEntity : MyNoSqlTableEntity, ITradingGroup
    {

        public static string GeneratePartitionKey()
        {
            return "g";
        }

        public static string GenerateRowKey(string id)
        {
            return id;
        }

        public string Id => RowKey;
        public double MarginCallPercent { get; set; }
        public double StopOutPercent { get; set; }



        IEnumerable<IInstrumentGroupInfo> ITradingGroup.Instruments => Instruments;
        public List<InstrumentGroupInfoMyNoSqlEntity> Instruments { get; set; }


        public static TradingGroupMyNoSqlEntity Create(ITradingGroup src)
        {
            return new TradingGroupMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                MarginCallPercent = src.MarginCallPercent,
                StopOutPercent = src.StopOutPercent,
                Instruments = src.Instruments.Select(InstrumentGroupInfoMyNoSqlEntity.Create).ToList()
            };
        }
        
    }
}