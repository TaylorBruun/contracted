using contracted.Models;
using contracted.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace contracted.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {

        private readonly JobsService _jobsService;

        public JobsController(JobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet]
        public ActionResult<List<Job>> GetAll()
        {
            try
            {
                List<Job> jobs = _jobsService.GetAll();
                return Ok(jobs);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job jobData)
        {
            try
            {
                Job job = _jobsService.Create(jobData);
                return Ok(job);
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
                _jobsService.Delete(id);
                return Ok("Deleted");
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


    }
}