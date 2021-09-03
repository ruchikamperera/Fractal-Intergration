using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Picklist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime RowModified { get; set; }     
        public string RowModifiedBy { get; set; }

    }
}
