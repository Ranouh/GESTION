using System;
using System.Linq;
using System.Threading.Tasks;
namespace GESTION.Dto.NoteSection
{
    public class UpdateNoteSectionRequestDto
    {
        public int note { get; set; }
        public int SectionId { get; set; }
        public int ExamStudentId { get; set; }
        public int CommentId {get;set;}
    }
}