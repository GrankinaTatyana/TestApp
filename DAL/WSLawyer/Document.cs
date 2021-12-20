using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class Document
    {
      

        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public long UserIdcreator { get; set; }
        public long? UserIdupdate { get; set; }
      
        public int? StatusType { get; set; }
        public string NumberDoc { get; set; }
        public DateTime DateDoc { get; set; }
        public string Description { get; set; }


    }
}
