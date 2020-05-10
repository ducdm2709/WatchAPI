using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class Storages
    {
        public int StorageId { get; set; }
        public int Amount { get; set; }
        public int WatchId { get; set; }

        public virtual Product Watch { get; set; }
    }
}
