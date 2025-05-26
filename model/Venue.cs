using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Venue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenue { get; set; }
        [Required(ErrorMessage = "VenueName is required and cannot be empty")]
        public string? VenueName { get; set; }

        public ICollection<Student> Students {get;set;}
    }
}