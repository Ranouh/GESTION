using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLevel { get; set; }

        [Required(ErrorMessage = "LevelName is required and cannot be empty")]
        public string? LevelName { get; set; }

        //navigation property
        public virtual ICollection<Exam> Exams { get; set; }
        
        public virtual ICollection<StudentLevel> StudentLevels { get; set; }
        
        public virtual ICollection<SectionScale> SectionScales{get;set;}

        public virtual ICollection<ProfLevel> ProfLevels {get;set;}
        
    }
}