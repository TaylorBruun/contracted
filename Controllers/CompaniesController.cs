using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace contracted.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _companiesService;

        public CompaniesController(CompaniesService companiesService)
        {
            _companiesService = companiesService;
        }


        [HttpGet]
        public ActionResult<List<Company>> GetAll()
        {
            try
            {
                List<Company> companies = _companiesService.GetAll();
                return Ok(companies);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetById(int id)
        {
            try
            {
                
            Company company = _companiesService.GetById(id);
            return Ok(company);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult<Company> Create([FromBody] Company companyData)
        {
            try
            {
                Company company = _companiesService.Create(companyData);
                return Ok(company);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Company> Update([FromBody] Company companyData, int id)
        {
            try
            {
                Company updatedCompany = _companiesService.Update(companyData, id);
                return Ok(updatedCompany);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _companiesService.Delete(id);
                return Ok("Deleted");
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}