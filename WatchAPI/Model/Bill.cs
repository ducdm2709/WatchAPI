using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetail = new HashSet<BillDetail>();
        }

        public int BillId { get; set; }
        public DateTime DateCreateBill { get; set; }
        public bool Status { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BillDetail> BillDetail { get; set; }
    }
}
