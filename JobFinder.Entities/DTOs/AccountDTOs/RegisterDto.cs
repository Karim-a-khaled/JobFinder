using System.ComponentModel.DataAnnotations;

namespace JobFinder.Entities.DTOs.AccountDTOs
{
    public class RegisterDto
    {

        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        public bool IsCompany { get; set; }
    }
}
