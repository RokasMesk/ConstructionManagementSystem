using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Construction.Models
{
    public class Worker
    {
        [Key]
        [Required]
        public int WorkerId { get; set; }
        [Required]
        [DisplayName("Workers Name")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Workers Last Name")]
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
