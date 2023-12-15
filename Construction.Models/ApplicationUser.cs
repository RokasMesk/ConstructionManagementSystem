using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Construction.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public int? WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        [Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidateNever]
        public Worker? Worker { get; set; }


    }
}
