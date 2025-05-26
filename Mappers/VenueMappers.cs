using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.Student;
using GESTION.Dto.Venue;
namespace GESTION.Mappers
{
    public static class VenueMappers
    {
        public static VenueDto ToVenueDto(this Venue venue)
        {
            if (venue == null)
            {
                throw new ArgumentNullException(nameof(venue), "venue is null");
            }

            return new VenueDto
            {
                IdVenue = venue.IdVenue,
                VenueName = venue.VenueName,
                Students = venue.Students?.Select(s => s.ToStudentDto()).ToList() ?? new List<StudentDto>()
            };
        }

        public static Venue ToVenueFromCreateDto(this CreateVenueRequestDto venueDto)
        {
            if (venueDto == null)
            {
                throw new ArgumentNullException(nameof(venueDto), "venueDto is null");
            }

            return new Venue
            {
                VenueName = venueDto.VenueName
            };
        }
    }
}
