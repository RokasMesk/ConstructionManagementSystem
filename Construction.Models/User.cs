using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; } 
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Password { get; set; }  


    }
}
