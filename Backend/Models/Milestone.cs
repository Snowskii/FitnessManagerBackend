using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Milestone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public int Limit { get; set; }
        public List<UserMilestone> UserMilestones { get; set; }
        public List<User> Users { get; set; }
    }
}
