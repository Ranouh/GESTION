using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.SectionScale;
namespace GESTION.Dto.Subject
{
    public class SubjectDto
    {
        public int IdSubject {get;set;}
        public string? SubjectName {get;set;}
        
        public List<SectionScaleDto> SectionScales {get;set;}
    }
}