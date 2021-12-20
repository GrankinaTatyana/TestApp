using System;
using System.Collections.Generic;

namespace DAL.WSLawyer
{
    public partial class Case
    {
        public Case()
        {
           
          
            SubjectCase = new HashSet<SubjectCase>();
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
     
        public long UserIdcreator { get; set; }
        public long? UserIdleader { get; set; }
        public long? UserIdAssistant { get; set; }
        public long? UserIdupdate { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int? StatusClaimRequirements { get; set; }
        public int? StatusCategory { get; set; }
        public int? StatusStage { get; set; }
        public int? StatusInstance{ get; set; }
        public DateTime? ClaimSubmitDate { get; set; }
        public float ClaimSumm { get; set; }
        public int? ResultStatus { get; set; }
        public DateTime? ResultDate { get; set; }
        public float ResultSumm{ get; set; }
        public bool FinansComeIntoForce { get; set; }
        public string CourtName { get; set; }
        public string Jurge { get; set; }
        public string CourtNumberCase{ get; set; }

        public virtual ICollection<SubjectCase> SubjectCase { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
