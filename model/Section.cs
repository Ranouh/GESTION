using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Section
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSection { get; set; }

        [Required(ErrorMessage = "SectionName is required and cannot be empty")]
        public string? SectionName { get; set; }

        //navigation property
        public virtual ICollection<NoteSection> NoteSections{get;set;}
        
        public virtual ICollection<SectionScale> SectionScales{get;set;}
    }
}