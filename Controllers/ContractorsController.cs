using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace contracted.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {

        private readonly ContractorsService _contractorsService;
        private readonly CompaniesService _companiesService;

        public ContractorsController(ContractorsService contractorsService, CompaniesService companiesService)
        {
            _contractorsService = contractorsService;
            _companiesService = companiesService;
        }

        [HttpGet]
        public ActionResult<List<Contractor>> GetAll()
        {
            try
            {
                List<Contractor> contractors = _contractorsService.GetAll();
                return Ok(contractors);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> GetById(int id)
        {
            try
            {
                
            Contractor contractor = _contractorsService.GetById(id);
            return Ok(contractor);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost]
        public ActionResult<Contractor> Create([FromBody] Contractor contractorData)
        {
            try
            {
                Contractor contractor = _contractorsService.Create(contractorData);
                return Ok(contractor);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contractor> Update([FromBody] Contractor contractorData, int id)
        {
            try
            {
                Contractor updatedContractor = _contractorsService.Update(contractorData, id);
                return Ok(updatedContractor);
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
                _contractorsService.Delete(id);
                return Ok("Deleted");
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{id}/companies")]
        public ActionResult<List<Company>> GetCompaniesByContractor(int id)
        {
            try
            {
            List<Company> companies = _companiesService.GetCompaniesByContractor(id);
            return Ok(companies);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}