using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSubject {get;set;}

        [Required(ErrorMessage = "LevelName is required and cannot be empty")]
        public string SubjectName {get;set;}

        public ICollection<SectionScale> SectionScales {get;set;}
    }
}