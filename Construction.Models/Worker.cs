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
        [DisplayName("Workers Number")]
        public string? Number { get; set; }
        [Required]
        [DisplayName("Workers title")]
        public string? WorkTitle { get; set; }
    }
}
