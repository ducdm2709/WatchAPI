using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class Product
    {
        public Product()
        {
            BillDetail = new HashSet<BillDetail>();
            Storages = new HashSet<Storages>();
            TopSell = new HashSet<TopSell>();
        }

        public int WatchId { get; set; }
        public string WatchName { get; set; }
        public int TradeMarkId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public virtual TradeMark TradeMark { get; set; }
        public virtual ICollection<BillDetail> BillDetail { get; set; }
        public virtual ICollection<Storages> Storages { get; set; }
        public virtual ICollection<TopSell> TopSell { get; set; }
    }
}
