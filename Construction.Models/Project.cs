using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }  
        public string? ProjectDescription { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime?  EndDate { get; set; } 
        public int WorkerId { get; set; }
        [ForeignKey(nameof(Worker))]
        public ICollection<Worker> ProjectWorkers { get; set; }

    }
}
