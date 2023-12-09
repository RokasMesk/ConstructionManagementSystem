using System.ComponentModel.DataAnnotations;

namespace Construction.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? ContactInformation { get; set; }
    }
}
