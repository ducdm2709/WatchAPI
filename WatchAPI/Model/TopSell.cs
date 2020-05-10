using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class TopSell
    {
        public int TopSellId { get; set; }
        public int WatchId { get; set; }
        public int? Times { get; set; }
        public int? Rating { get; set; }

        public virtual Product Watch { get; set; }
    }
}
