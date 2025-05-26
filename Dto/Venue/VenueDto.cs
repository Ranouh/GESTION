using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GESTION.Dto.Student;
namespace GESTION.Dto.Venue
{
    public class VenueDto
    {
        public int IdVenue { get; set; }
        public string? VenueName { get; set; }

        public List<StudentDto> Students {get;set;}
    }
}