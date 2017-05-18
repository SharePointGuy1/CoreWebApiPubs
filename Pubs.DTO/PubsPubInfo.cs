using System;
using System.Collections.Generic;

namespace PubsConsoleApp.Entities
{
    public partial class PubsPubInfo
    {
        public string PubId { get; set; }
        public byte[] Logo { get; set; }
        public string PrInfo { get; set; }

        public virtual PubsPublishers Pub { get; set; }
    }
}
