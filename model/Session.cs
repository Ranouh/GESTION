using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSession{get;set;}

        [Required(ErrorMessage="NameSession is required and cannot be empty")]
        public string? SessionName{get;set;}

        public virtual ICollection<Exam> Exams{get;set;}
    }
}