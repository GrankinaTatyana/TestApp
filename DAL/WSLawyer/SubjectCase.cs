using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class SubjectCase
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public long SubjectId { get; set; }
        public int CaseId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public long UserIdcreator { get; set; }
        public long? UserIdupdate { get; set; }
   
        public virtual Case Case { get; set; }
        public virtual Subject Subject { get; set; }
      
    }
}
