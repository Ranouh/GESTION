using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.Student;
namespace GESTION.Dto.Nationality
{
    public class NationalityDto
    {
        public int IdNationality { get; set; }
        public string? NationalityName { get; set; }

        public  List <StudentDto> Students {get;set;}
    }
}