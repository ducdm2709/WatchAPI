using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class BillDetail
    {
        public int BillDetailId { get; set; }
        public int BillId { get; set; }
        public int WatchId { get; set; }
        public int Amount { get; set; }
        public double TotalPay { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Product Watch { get; set; }
    }
}
