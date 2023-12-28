using System.ComponentModel.DataAnnotations;

namespace JobFinder.Entities.DTOs
{
    public class LoginDto 
    {
        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        public string Password { get; set; }
    }
}
