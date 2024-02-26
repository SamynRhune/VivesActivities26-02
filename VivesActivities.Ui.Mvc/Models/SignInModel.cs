using System.ComponentModel.DataAnnotations;

namespace VivesActivities.Ui.Mvc.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress]
        public required string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}
