using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class ColumnList
    {
        public ColumnList()
        {
            Status = new HashSet<Status>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectListId { get; set; }
        public string ColumnName { get; set; }
        public bool NotEdited { get; set; }
        public string TableName { get; set; }

       
        public virtual ICollection<Status> Status { get; set; }
    }
}
