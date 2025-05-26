using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.NoteSection;
namespace GESTION.Mappers
{
    public static class NoteSectionMappers
    {
        public static NoteSectionDto ToNoteSectionDto(this NoteSection noteSection)
        {
            if (noteSection == null)
            {
                throw new ArgumentNullException(nameof(noteSection), "noteSection is null");
            }

            return new NoteSectionDto
            {
                IdNoteSection = noteSection.IdNoteSection,
                note = noteSection.note,
                SectionId = noteSection.SectionId,
                SectionName = noteSection.Section?.SectionName?? string.Empty,
                ExamStudentId = noteSection.ExamStudentId,
                CommentId = noteSection.CommentId,
                CommentText = noteSection.Comment?.CommentText?? string.Empty
            };
        }

        public static NoteSection ToNoteSectionFromCreateDto(this CreateNoteSectionRequestDto noteSectionDto)
        {
            if (noteSectionDto == null)
            {
                throw new ArgumentNullException(nameof(noteSectionDto), "noteSectionDto is null");
            }

            return new NoteSection
            {
                note = noteSectionDto.note,
                SectionId = noteSectionDto.SectionId,
                ExamStudentId = noteSectionDto.ExamStudentId,
                CommentId = noteSectionDto.CommentId
            };
        }
    }
    }
