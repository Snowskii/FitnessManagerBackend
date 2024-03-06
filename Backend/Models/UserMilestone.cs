namespace Backend.Models
{
    public class UserMilestone
    {

        public int UserId { get; set; }
        public int MilestoneId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Milestone Milestone { get; set; }
    }
}
