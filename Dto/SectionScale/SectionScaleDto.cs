using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GESTION.Dto.SectionScale
{
    public class SectionScaleDto
    {
        public int IdSectionScale {get;set;}
        public int scale {get;set;}
        public int SectionId {get;set;}
        public string SectionName{get;set;}
        public int LevelId {get;set;}
        public string LevelName {get;set;}
        public int SubjectId {get;set;}
        public string SubjectName {get;set;}
    }
}