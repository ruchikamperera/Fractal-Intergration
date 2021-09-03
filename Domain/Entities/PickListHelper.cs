using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class PicklistHelper
    {
        public int PickListHelperID { get; set; }
        public string TableName { get; set; }
        public string HelperText { get; set; }
        public DateTime RowModified { get; set; }
        public string RowModifiedBy { get; set; }

    }
}
