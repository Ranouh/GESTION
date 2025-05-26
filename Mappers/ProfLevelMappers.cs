using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.ProfLevel;
namespace GESTION.Mappers
{
    public static class ProfLevelMappers
    {
        public static ProfLevelDto ToProfLevelDto(this ProfLevel profLevel)
        {
            if (profLevel == null)
            {
                throw new ArgumentNullException(nameof(profLevel), "profLevel is null");
            }

            return new ProfLevelDto
            {
                IdProfLevel = profLevel.IdProfLevel,
                StaffId = profLevel.StaffId,
                StaffName = profLevel.Staff?.StaffName?? string.Empty,
                LevelId = profLevel.LevelId,
                LevelName = profLevel.Level?.LevelName?? string.Empty,
                PeriodId = profLevel.PeriodId,
                PeriodName = profLevel.Period?.PeriodName?? string.Empty
            };
        }

        public static ProfLevel ToProfLevelFromCreateDto(this CreateProfLevelRequestDto profLevelDto)
        {
            if (profLevelDto == null)
            {
                throw new ArgumentNullException(nameof(profLevelDto), "profLevelDto is null");
            }

            return new ProfLevel
            {
                StaffId = profLevelDto.StaffId,
                LevelId = profLevelDto.LevelId,
                PeriodId = profLevelDto.PeriodId
            };
        }
    }
}
