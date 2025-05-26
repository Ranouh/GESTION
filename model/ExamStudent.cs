using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class ExamStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExamStudent {get;set;}

        [Required(ErrorMessage = "IdStudent is required and cannot be empty")]
        public int StudentId {get;set;}
        public virtual Student Student {get;set;}
        
        [Required(ErrorMessage = "IdExam is required and cannot be empty")]
        public int ExamId{get;set;}
        public virtual Exam Exam {get;set;}


        public virtual ICollection<NoteSection> NoteSections{get;set;}
    }
}