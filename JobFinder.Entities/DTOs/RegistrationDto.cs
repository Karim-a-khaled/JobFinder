using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs
{
    public class RegistrationDto 
    {
        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        public string Name { get; set; }

        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        public string Email { get; set; }

        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "FIELD_IS_REQUIRED")]
        public bool isCompany { get; set; }
    }
}
