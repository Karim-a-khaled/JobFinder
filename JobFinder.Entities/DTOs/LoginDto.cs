using JobFinder.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
