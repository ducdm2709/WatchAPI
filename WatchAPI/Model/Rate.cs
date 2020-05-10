using System;
using System.Collections.Generic;

namespace WatchAPI.Model
{
    public partial class Rate
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int WatchId { get; set; }
        public string Comment { get; set; }
        public int? Rating { get; set; }
    }
}
