using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.SectionScale
{
    public class CreateSectionScaleRequestDto
    {
        public int scale {get;set;}
        public int SectionId {get;set;}
        public int LevelId {get;set;}
        public int SubjectId {get;set;}
    }
}