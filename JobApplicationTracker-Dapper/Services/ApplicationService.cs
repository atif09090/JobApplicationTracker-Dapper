using System.Data;
using Dapper;
using JobApplicationTracker_Dapper.Models;

namespace JobApplicationTracker_Dapper.Services
{
    public class ApplicationService
    {
        private readonly IDbConnection _connection;

        public ApplicationService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Application> GetByEmailAsync(string email)
        {
            return await _connection.QueryFirstOrDefaultAsync<Application>(
                "SELECT * FROM Applications WHERE Email = @Email",
                new { Email = email });
        }

        public async Task<IEnumerable<Application>> GetByJobAndStatusAsync(int jobId, string status)
        {
            return await _connection.QueryAsync<Application>(
                @"SELECT * FROM Applications 
              WHERE JobId = @JobId AND Status = @Status 
              ORDER BY AppliedDate DESC",
                new { JobId = jobId, Status = status });
        }

        public async Task AddApplicationAsync(Application application)
        {
            var sql = @"INSERT INTO Applications (JobId, CandidateName, Email, ResumeUrl, Status, AppliedDate)
                    VALUES (@JobId, @CandidateName, @Email, @ResumeUrl, @Status, @AppliedDate)";
            await _connection.ExecuteAsync(sql, application);
        }
    }

}
