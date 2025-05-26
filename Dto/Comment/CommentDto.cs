using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.model;
using GESTION.Dto.NoteSection;
namespace GESTION.Dto.Comment
{
    public class CommentDto
    {
        public int IdComment{get;set;}
        public string? CommentText {get;set;}

        public virtual List<NoteSectionDto> NoteSections{get;set;}
    }
}