using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {


        private readonly CaseDataMappingService _caseDataMappingService;



        public CaseController(CaseDataMappingService caseDataMappingService)
        {
            _caseDataMappingService = caseDataMappingService;
            
        }
        
        [HttpGet("GetCase")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _caseDataMappingService.GetCaseByCaseId(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                JsonObjectForResponse response = new JsonObjectForResponse();
                response.status = false;
                response.message = "Ошибка." + e.Message;
                return BadRequest(e.Message);
            }

        }



        [HttpPost("CreateOrUpdateCase")]
        public IActionResult CreateOrUpdateCase(IFormCollection formCollection,  bool flag)
        {
            try
            {
                JsonObjectForResponse response = new JsonObjectForResponse();
                CaseViewDTO Object = new CaseViewDTO();
                Object =
                    JsonConvert.DeserializeObject<CaseViewDTO>(formCollection.ElementAt(0).Value);

                var result = _caseDataMappingService.UpdateCaseFromCaseView(Object, flag);
                return Ok(result);
            }
            catch (Exception e)
            {
                JsonObjectForResponse response = new JsonObjectForResponse();
                response.status = false;
                response.message = "Ошибка." + e.Message;
                return BadRequest(e.Message);
            }
        }

    
    }
}
