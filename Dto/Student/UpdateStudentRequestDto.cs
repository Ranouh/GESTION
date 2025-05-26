using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.Student
{
    public class UpdateStudentRequestDto
    {
        public string? StudentMatricule { get; set; }
        public string? StudentName { get; set; }
        public string? StudentFirstName { get; set; }
        public DateTime StudentBirth { get; set; }
        public string? StudentGender { get; set; }
        public string? StudentHomeAddress { get; set; }
        public string? StudentPhoneNumber { get; set; }
        public string? StudentEmailAddress { get; set; }
        public int NationalityId { get; set; }
        public int VenueId { get; set; }
    }
}