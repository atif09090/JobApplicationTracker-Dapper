namespace JobApplicationTracker_Dapper.Models
{
    public class JobPost
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public DateTime PostedDate { get; set; }
    }

}
