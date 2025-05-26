using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.SectionScale;
namespace GESTION.Mappers
{
    public static class SectionScaleMappers
    {
        public static SectionScaleDto ToSectionScaleDto(this SectionScale sectionScale)
        {
            if (sectionScale == null)
            {
                throw new ArgumentNullException(nameof(sectionScale), "sectionScale is null");
            }
            return new SectionScaleDto
            {
                IdSectionScale = sectionScale.IdSectionScale,
                scale = sectionScale.scale,
                SectionId = sectionScale.SectionId,
                SectionName = sectionScale.Section?.SectionName,
                LevelId = sectionScale.LevelId,
                LevelName = sectionScale.Level?.LevelName,
                SubjectId = sectionScale.SubjectId,
                SubjectName = sectionScale.Subject?.SubjectName
            };
        }

        public static SectionScale ToSectionScaleFromCreateDto(this CreateSectionScaleRequestDto sectionScaleDto)
        {
            if (sectionScaleDto == null)
            {
                throw new ArgumentNullException(nameof(sectionScaleDto), "sectionScaleDto is null");
            }

            return new SectionScale
            {
                scale = sectionScaleDto.scale,
                SectionId = sectionScaleDto.SectionId,
                LevelId = sectionScaleDto.LevelId,
                SubjectId = sectionScaleDto.SubjectId
            };
        }
    }
}
