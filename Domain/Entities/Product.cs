using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string AssetType { get; set; }
        public string BusinessCriticality { get; set; }
        public string Vendor { get; set; }
        public string ConfigItem { get; set; }
        public string Comments { get; set; }
        public string Strategy { get; set; }
        public string Image { get; set; }

    }
}
