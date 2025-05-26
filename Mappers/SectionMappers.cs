using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;

using GESTION.Dto.SectionScale;
using GESTION.Dto.NoteSection;
using GESTION.Dto.Section;

namespace GESTION.Mappers
{
    public static class SectionMappers
    {
        public static SectionDto ToSectionDto(this Section section)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section), "section is null");
            }

            return new SectionDto
            {
                IdSection = section.IdSection,
                SectionName = section.SectionName,
                SectionScales = section.SectionScales?.Select(ss=>ss.ToSectionScaleDto()).ToList()?? new List <SectionScaleDto>(),
                NoteSections = section.NoteSections?.Select(ns=>ns.ToNoteSectionDto()).ToList()?? new List <NoteSectionDto>()
            };
        }

        public static Section ToSectionFromCreateDto(this CreateSectionRequestDto sectionDto)
        {
            if (sectionDto == null)
            {
                throw new ArgumentNullException(nameof(sectionDto), "sectionDto is null");
            }

            return new Section
            {
                SectionName = sectionDto.SectionName
            };
        }
    }
}