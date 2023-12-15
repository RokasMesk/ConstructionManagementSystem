using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Construction.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        [Required]
        [DisplayName("Workers Name")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Workers Last Name")]
        public string? LastName { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
    }
}
