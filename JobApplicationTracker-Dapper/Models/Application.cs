namespace JobApplicationTracker_Dapper.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int JobId { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public string ResumeUrl { get; set; }
        public string Status { get; set; }
        public DateTime AppliedDate { get; set; }
    }

}
