using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.WSLawyer
{
    public partial class Task
    {
      

        public long Id { get; set; }
        public int StatusType { get; set; }
        public string TaskTarget { get; set; }
        public DateTime BeginDate { get; set; }
        public long? UserIdexecutor { get; set; }
        public long UserIdcreator { get; set; }
        public DateTime? DateEndPlan { get; set; }
        public DateTime? DateEndFact { get; set; }
        public int Status { get; set; }
        public string TaskResult { get; set; }
       
        public int CaseId { get; set; }
        public int Level { get; set; }
        public int SpentTime { get; set; }
        public long? UserIdupdate { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
      
        public bool OnConfirmation { get; set; }
      
        public DateTime? DateCompletion { get; set; }
       

        public virtual Case Case { get; set; }
     
       
    
       
    }
}
