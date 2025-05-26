using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.SectionScale;
using GESTION.Dto.NoteSection;
namespace GESTION.Dto.Section
{
    public class SectionDto
    {
        public int IdSection { get; set; }
        public String? SectionName { get; set; }
        
        public List<SectionScaleDto> SectionScales{get;set;}
        public List<NoteSectionDto> NoteSections{get;set;}
    }
}