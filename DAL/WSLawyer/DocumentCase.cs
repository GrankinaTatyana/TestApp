using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class DocumentCase
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public long UserIdcreator { get; set; }
        public long? UserIdupdate { get; set; }
        public int? CaseId { get; set; }
        public int? DocumentId { get; set; }
    }
}
