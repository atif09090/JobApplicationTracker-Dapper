using Dapper;
using JobApplicationTracker_Dapper.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Data;

namespace JobApplicationTracker_Dapper.Services
{
    public class JobService
    {
        private readonly IMemoryCache _cache;
        private readonly IDbConnection _connection;

        public JobService(IMemoryCache cache, IDbConnection connection)
        {
            _cache = cache;
            _connection = connection;
        }

        public async Task<List<JobPost>> GetActiveJobPostsAsync()
        {
            if (!_cache.TryGetValue("active_jobs", out List<JobPost> jobs))
            {
                jobs = (await _connection.QueryAsync<JobPost>(
                    "SELECT * FROM JobPosts WHERE PostedDate >= DATEADD(DAY, -30, GETDATE())"))
                    .ToList();

                _cache.Set("active_jobs", jobs, TimeSpan.FromMinutes(10));
            }

            return jobs;
        }
    }

}
