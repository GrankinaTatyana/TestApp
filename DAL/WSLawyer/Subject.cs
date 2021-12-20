using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class Subject
    {
        public Subject()
        {
           
            SubjectCase = new HashSet<SubjectCase>();
           
        }

        public long Id { get; set; }
       
        public string Name { get; set; }
        public int StatusJuridical { get; set; }
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Ogrn { get; set; }
        public long UserIdcreator { get; set; }
        public long? UserIdupdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }  
        public string Snils { get; set; }
        public string PassNumber { get; set; }

    
        public virtual ICollection<SubjectCase> SubjectCase { get; set; }
      }
    
}
