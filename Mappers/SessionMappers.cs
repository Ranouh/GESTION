using System;
using System.Collections.Generic;
using System.Linq;
using GESTION.model;
using GESTION.Dto.Exam;
using GESTION.Dto.Session;
namespace GESTION.Mappers
{
    public static class SessionMappers
    {
        public static SessionDto ToSessionDto(this Session session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session), "session is null");
            }

            return new SessionDto
            {
                IdSession = session.IdSession,
                SessionName = session.SessionName,
                Exams = session.Exams?.Select(e => e.ToExamDto()).ToList() ?? new List<ExamDto>()
            };
        }

        public static Session ToSessionFromCreateDto(this CreateSessionRequestDto sessionDto)
        {
            if (sessionDto == null)
            {
                throw new ArgumentNullException(nameof(sessionDto), "sessionDto is null");
            }

            return new Session
            {
                SessionName = sessionDto.SessionName
            };
        }
    }
}