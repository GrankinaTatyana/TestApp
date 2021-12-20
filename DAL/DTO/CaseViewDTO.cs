using DAL.WSLawyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.DTO
{
    public partial class CaseViewDTO
    {
        
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
        public int? StatusInstance { get; set; }
        public DateTime? ClaimSubmitDate { get; set; }
        public float ClaimSumm { get; set; }
        public int? ResultStatus { get; set; }
        public DateTime? ResultDate { get; set; }
        public float ResultSumm { get; set; }
        public bool FinansComeIntoForce { get; set; }
        public string CourtName { get; set; }
        public string Jurge { get; set; }
        public string CourtNumberCase { get; set; }
        public List<Document> documnets { get; set; }

        public List<SubjectView> subjectsviews
        {
            get
            {

                var _subjectsviews = new List<SubjectView>();
                foreach (var cur in subjects)
                {
                    _subjectsviews.Add(new SubjectView(){subject = cur, statustype= subjectsCases.FirstOrDefault(x=>x.Status==cur.Id).Status});
                }

                return _subjectsviews;

            }
          
        }

        public List<Subject> subjects { get; set; }
        public List<SubjectCase> subjectsCases { get; set; }
        public List<Task> tasks { get; set; }

        public class SubjectView
        {
            public Subject subject { get; set; }
            public int statustype { get; set; }
        }


    }
}
