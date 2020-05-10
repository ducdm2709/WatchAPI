using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class TradeMark
    {
        public TradeMark()
        {
            Product = new HashSet<Product>();
        }

        public int TradeMarkId { get; set; }
        public string TradeMarkName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
