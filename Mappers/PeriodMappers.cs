using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.Exam;
using GESTION.Dto.StudentLevel;
using GESTION.Dto.ProfLevel;
using GESTION.Dto.Period;
namespace GESTION.Mappers
{
    public static class PeriodMappers
    {
        public static PeriodDto ToPeriodDto(this Period period)
        {
            if (period == null)
            {
                throw new ArgumentNullException(nameof(period), "period is null");
            }

            return new PeriodDto
            {
                IdPeriod = period.IdPeriod,
                Year = period.Year,
                PeriodName = period.PeriodName,
                Exams = period.Exams?.Select(e=>e.ToExamDto()).ToList()?? new List<ExamDto>(),
                StudentLevels = period.StudentLevels?.Select(sl=>sl.ToStudentLevelDto()).ToList()?? new List<StudentLevelDto>(),
                ProfLevels = period.ProfLevels?.Select(pl=>pl.ToProfLevelDto()).ToList() ?? new List<ProfLevelDto>()
            };
        }

        public static Period ToPeriodFromCreateDto(this CreatePeriodRequestDto periodDto)
        {
            if (periodDto == null)
            {
                throw new ArgumentNullException(nameof(periodDto), "periodDto is null");
            }

            return new Period
            {
                Year = periodDto.Year,
                PeriodName = periodDto.PeriodName
            };
        }
    }
}
