using MyNoSqlRepositories.Abstraction.Markups;
using MyNoSqlRepositories.Abstraction.Trading.Instruments;

namespace MyNoSqlRepositories.Abstraction.BidAsk;

public static class BidAskUtils
{
    public static IBidAsk AddMarkups(this IBidAsk bidAsk, ITradingInstrument targetInstrument, IIMarkupProfileBase markupProfile)
    {
        if (!markupProfile.MarkupInstruments.ContainsKey(bidAsk.Id))
            return bidAsk;

        var targetMarkupInstrument = markupProfile.MarkupInstruments[bidAsk.Id];

        bidAsk.Ask = bidAsk.Ask.AddPips(targetMarkupInstrument.MarkupAsk, targetInstrument.Digits);
        bidAsk.Bid = bidAsk.Bid.AddPips(targetMarkupInstrument.MarkupBid, targetInstrument.Digits);

        return bidAsk;
    }
        
        
    private static double AddPips(this double rate, int pips, int digits)
    {
        return rate + pips * Math.Pow(0.1, digits);
    }
}