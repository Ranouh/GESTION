using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdComment{get;set;}

        [Required(ErrorMessage="Comment is required and cannot be empty")]
        public string CommentText {get;set;}

        public virtual ICollection<NoteSection> NoteSections{get;set;}
    }
}