using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivesActivities.Model
{
    [Table(nameof(VivesActivity))]
    public class VivesActivity
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }

        [Display(Name= "Activity type")]
        public string? Type { get; set; }

        public int LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
