using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;

using GESTION.Dto.Level;
using GESTION.Dto.ProfLevel;
using GESTION.Dto.Exam;
using GESTION.Dto.StudentLevel;

namespace GESTION.Mappers
{
    public static class LevelMappers
    {
        public static LevelDto ToLevelDto(this Level level)
        {
            if (level == null)
            {
                throw new ArgumentNullException(nameof(level), "Level is null");
            }

            return new LevelDto
            {
                IdLevel = level.IdLevel,
                LevelName = level.LevelName,
                Exams = level.Exams?.Select(e=>e.ToExamDto()).ToList()?? new List<ExamDto>(),
                ProfLevels = level.ProfLevels?.Select(pl=>pl.ToProfLevelDto()).ToList()?? new List<ProfLevelDto>(),
                StudentLevels = level.StudentLevels?.Select(sl=>sl.ToStudentLevelDto()).ToList()?? new List<StudentLevelDto>()
            };
        }

        public static Level ToLevelFromCreateDto(this CreateLevelRequestDto levelDto)
        {
            if (levelDto == null)
            {
                throw new ArgumentNullException(nameof(levelDto), "CreateLevelRequestDto is null");
            }

            return new Level
            {
                LevelName = levelDto.LevelName
            };
        }
    }
}
