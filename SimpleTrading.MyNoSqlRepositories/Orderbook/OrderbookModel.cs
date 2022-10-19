using System.Collections.Generic;

namespace SimpleTrading.Orderbook
{
    public class OrderbookModel
    {
        public string Market { get; set; }
        public long Ts { get; set; }
        public Dictionary<string, string> Bids { get; set; }
        public Dictionary<string, string> Asks { get; set; }
    }
}