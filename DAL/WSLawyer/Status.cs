using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class Status
    {
        public long Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public int ColumnListId { get; set; }
        public bool? NotEdited { get; set; }
        public bool? NotVisible { get; set; }
        public string NameSecond { get; set; }
        public int? RefValue { get; set; }

        public virtual ColumnList ColumnList { get; set; }
    }
}
