using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DAL.WSLawyer.Repositories
{
    public interface ICaseRepository
    { 
        Case Get(int id);
        CaseViewDTO GetCaseViewByCaseId(int id);
        bool UpdateCaseFromCaseView(CaseViewDTO case_, bool flag); //1-add,0-upd

    }


    public class CaseRepository : Repository<Case>, ICaseRepository
    {
        private WsLawyerDbContext _lawyerDbContext;

        public CaseRepository(WsLawyerDbContext context) : base(context)
        {
            _lawyerDbContext = context;
           
        }

        public CaseViewDTO GetCaseViewByCaseId(int id)
        {

            var res = new CaseViewDTO();
            var case_=_lawyerDbContext.Case.FirstOrDefault(x => x.Id == id);
            if (case_ != null)
            {

                res.Id = case_.Id;

                res.UserIdcreator = case_.UserIdcreator;
                res.UserIdleader = case_.UserIdleader;
                res.UserIdAssistant = case_.UserIdAssistant;
                res.UserIdupdate = case_.UserIdupdate;
                res.DateCreate = case_.DateCreate;
                res.DateUpdate = case_.DateUpdate;
                res.StatusClaimRequirements = case_.StatusClaimRequirements;
                res.StatusCategory = case_.StatusCategory;
                res.StatusStage = case_.StatusStage;
                res.StatusInstance = case_.StatusInstance;
                res.ClaimSubmitDate = case_.ClaimSubmitDate;
                res.ClaimSumm = case_.ClaimSumm;
                res.ResultStatus = case_.ResultStatus;
                res.ResultDate = case_.ResultDate;
                res.ResultSumm = case_.ResultSumm;
                res.FinansComeIntoForce = case_.FinansComeIntoForce;
                res.CourtName = case_.CourtName;
                res.Jurge = case_.Jurge;
                res.CourtNumberCase = case_.CourtNumberCase;

                 var docCases = _lawyerDbContext.DocumentCase.Where(x => x.CaseId == id);
                foreach (var cur in docCases)
                {
                   res.documnets.Add(_lawyerDbContext.Document.FirstOrDefault(x => x.Id==cur.DocumentId)); 
                }
                var subCases = _lawyerDbContext.SubjectCase.Where(x => x.CaseId == id);
                foreach (var cur in subCases)
                {
                    res.subjects.Add(_lawyerDbContext.Subject.FirstOrDefault(x => x.Id == cur.SubjectId));
                }
                res.subjectsCases.Add(_lawyerDbContext.SubjectCase.FirstOrDefault(x => x.CaseId == id));
                res.tasks.Add(_lawyerDbContext.Task.FirstOrDefault(x => x.CaseId== id));
               
            }

            return res;

        }


        public bool UpdateCaseFromCaseView(CaseViewDTO  case_, bool flag)
        {
            try
            {
                var res = _lawyerDbContext.Case.FirstOrDefault(x => x.Id == case_.Id);
                if(res==null && flag)res=new Case();
                if (res != null)
                {
                    res.Id = case_.Id;

                    res.UserIdcreator = case_.UserIdcreator;
                    res.UserIdleader = case_.UserIdleader;
                    res.UserIdAssistant = case_.UserIdAssistant;
                    res.UserIdupdate = case_.UserIdupdate;
                    res.DateCreate = case_.DateCreate;
                    res.DateUpdate = case_.DateUpdate;
                    res.StatusClaimRequirements = case_.StatusClaimRequirements;
                    res.StatusCategory = case_.StatusCategory;
                    res.StatusStage = case_.StatusStage;
                    res.StatusInstance = case_.StatusInstance;
                    res.ClaimSubmitDate = case_.ClaimSubmitDate;
                    res.ClaimSumm = case_.ClaimSumm;
                    res.ResultStatus = case_.ResultStatus;
                    res.ResultDate = case_.ResultDate;
                    res.ResultSumm = case_.ResultSumm;
                    res.FinansComeIntoForce = case_.FinansComeIntoForce;
                    res.CourtName = case_.CourtName;
                    res.Jurge = case_.Jurge;
                    res.CourtNumberCase = case_.CourtNumberCase;
                    foreach (var doc in case_.documnets)
                    {
                        var tmp = _lawyerDbContext.Document.FirstOrDefault(x => x.Id == doc.Id);
                        if (tmp != null)
                        {
                            _lawyerDbContext.Document.Update(doc);
                        }
                        else _lawyerDbContext.Document.Add(doc);

                    }
                    foreach (var sub in case_.subjects)
                    {
                        var tmp = _lawyerDbContext.Subject.FirstOrDefault(x => x.Id == sub.Id);
                        if (tmp != null)
                        {
                            _lawyerDbContext.Subject.Update(sub);
                        }
                        else _lawyerDbContext.Subject.Add(sub);

                    }
                    foreach (var task in case_.tasks)
                    {
                        var tmp = _lawyerDbContext.Task.FirstOrDefault(x => x.Id == task.Id);
                        if (tmp != null)
                        {
                            _lawyerDbContext.Task.Update(task);
                        }
                        else _lawyerDbContext.Task.Add(task);
                    }

                    //методы для удаления субъектов,сторон,документов и правка связей,если на форме что-то было удалено
                    ///
                    ///
                    /// 
                    return true;
                }
                else return false;
            }        
            
            catch (Exception e)
            {
                return false;
            }
        }




    }
}
