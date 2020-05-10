using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class InfoAccount
    {
        public int InfoAccountId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
