
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using DAL;
using DAL.WSLawyer;
using DAL.DTO;

namespace WebApplication3.Services
{
    public class CaseDataMappingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CaseDataMappingService(IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
        }

        public CaseViewDTO GetCaseByCaseId(int id)
        {
            var case_ = _unitOfWork.CaseRepository.GetCaseViewByCaseId(id);
            return case_;
        }

        public bool UpdateCaseFromCaseView(CaseViewDTO case_, bool flag)
        {
            var res_ = _unitOfWork.CaseRepository.UpdateCaseFromCaseView(case_, flag);
            _unitOfWork.SaveChanges();
            return res_;
        }


    }
}
