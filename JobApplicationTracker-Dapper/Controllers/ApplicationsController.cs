using JobApplicationTracker_Dapper.Models;
using JobApplicationTracker_Dapper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationTracker_Dapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly ApplicationService _applicationService;
        private readonly JobService _jobService;

        public ApplicationsController(ApplicationService applicationService, JobService jobService)
        {
            _applicationService = applicationService;
            _jobService = jobService;
        }

        [HttpGet("by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var app = await _applicationService.GetByEmailAsync(email);
            if (app == null) return NotFound();
            return Ok(app);
        }

        [HttpGet("by-job")]
        public async Task<IActionResult> GetByJobAndStatus([FromQuery] int jobId, [FromQuery] string status)
        {
            var apps = await _applicationService.GetByJobAndStatusAsync(jobId, status);
            return Ok(apps);
        }

        [HttpGet("active-jobs")]
        public async Task<IActionResult> GetActiveJobs()
        {
            var jobs = await _jobService.GetActiveJobPostsAsync();
            return Ok(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> Apply([FromBody] Application application)
        {
            application.AppliedDate = DateTime.UtcNow;
            application.Status = "Submitted";
            await _applicationService.AddApplicationAsync(application);
            return CreatedAtAction(nameof(GetByEmail), new { email = application.Email }, application);
        }
    }

}
