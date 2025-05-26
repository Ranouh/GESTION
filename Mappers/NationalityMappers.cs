using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.Student;
using GESTION.Dto.Nationality;
namespace GESTION.Mappers
{
    public static class NationalityMappers
    {
        public static NationalityDto ToNationalityDto(this Nationality nationality)
        {
            if (nationality == null)
            {
                throw new ArgumentNullException(nameof(nationality), "nationality is null");
            }

            return new NationalityDto
            {
                IdNationality = nationality.IdNationality,
                NationalityName = nationality.NationalityName,
                Students = nationality.Students?.Select(s => s.ToStudentDto()).ToList() ?? new List<StudentDto>()
            };
        }

        public static Nationality ToNationalityFromCreateDto(this CreateNationalityRequestDto nationalityDto)
        {
            if (nationalityDto == null)
            {
                throw new ArgumentNullException(nameof(nationalityDto), "nationalityDto is null");
            }

            return new Nationality
            {
                NationalityName = nationalityDto.NationalityName
            };
        }
    }
}