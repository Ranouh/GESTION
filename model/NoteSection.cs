using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class NoteSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNoteSection {get;set;}

        [Required(ErrorMessage="Note is required and cannot be empty")]
        public int note {get;set;}
        
        [Required(ErrorMessage="ExamStudent is required cannot empty")]
        public int ExamStudentId {get;set;}
        public virtual ExamStudent ExamStudent {get;set;}

        [Required(ErrorMessage="Section is required cannot be empty")]
        public int SectionId{get;set;}
        public virtual Section Section {get;set;}

        [Required(ErrorMessage="Comment is required cannot be empty")]
        public int CommentId {get;set;}
        public virtual Comment Comment{get;set;}

    }
}