using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.SectionScale;
using GESTION.Dto.Subject;

namespace GESTION.Mappers
{
    public static  class SubjectMappers
    {
        public static SubjectDto ToSubjectDto(this Subject subject){
            if(subject==null){
                throw new ArgumentNullException(nameof(subject),"subject is null");
            }
            return new SubjectDto{
                IdSubject = subject.IdSubject,
                SubjectName = subject.SubjectName,
                SectionScales = subject.SectionScales?.Select(ss=>ss.ToSectionScaleDto()).ToList() ?? new List<SectionScaleDto>()
            };
        }
        public static Subject ToSubjectFromCreateDto(this CreateSubjectRequestDto subjectDto){
            if(subjectDto == null){
                throw new ArgumentNullException(nameof(subjectDto), "subjectDto is null");
            }
            return new Subject{
                SubjectName = subjectDto.SubjectName
            };
        }
    }
}