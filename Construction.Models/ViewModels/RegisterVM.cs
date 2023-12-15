using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Construction.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a role")]
        public string Role { get; set; } = string.Empty;
        public IEnumerable<SelectListItem>? PossibleRoles;
    }
}
