using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class Account
    {
        public Account()
        {
            InfoAccount = new HashSet<InfoAccount>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool TypeAccount { get; set; }
        public string Email { get; set; }

        public virtual ICollection<InfoAccount> InfoAccount { get; set; }
    }
}
