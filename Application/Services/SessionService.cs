using Application.Interfaces;
using Application.Models.Session;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public List<SessionDTO> GetAll()
        {
            var sessions = _sessionRepository.GetAll();

            return sessions.Select(s => new SessionDTO
            {
                Id = s.Id,
                UserId = s.UserId,
                Token = s.Token,
                EmissionDate = s.EmissionDate,
                RevocationDate = s.RevocationDate,
                ExpirationDate = s.ExpirationDate
            }).ToList();
        }

        public SessionDTO? GetById(int id)
        {
            var session = _sessionRepository.GetById(id);

            if (session == null) return null;

            return new SessionDTO
            {
                Id = session.Id,
                UserId = session.UserId,
                Token = session.Token,
                EmissionDate = session.EmissionDate,
                RevocationDate = session.RevocationDate,
                ExpirationDate = session.ExpirationDate
            };
        }

        public SessionDTO Add(CreateSessionDTO session)
        {
            var newSession = new Session
            {
                UserId = session.UserId,
                Token = session.Token,
                EmissionDate = DateTime.Now,
                RevocationDate = session.RevocationDate,
                ExpirationDate = session.ExpirationDate
            };

            var addedSession = _sessionRepository.Add(newSession);

            var newSessionDTO = new SessionDTO
            {
                Id = addedSession.Id,
                UserId = addedSession.UserId,
                Token = addedSession.Token,
                EmissionDate = addedSession.EmissionDate,
                RevocationDate = addedSession.RevocationDate,
                ExpirationDate= addedSession.ExpirationDate,
            };
            return newSessionDTO;
        }

        public SessionDTO? Update(SessionDTO session)
        {
            var updateSession = _sessionRepository.GetById(session.Id);

            if (updateSession == null) return null;

            updateSession.Id = session.Id;
            updateSession.UserId = session.UserId;
            updateSession.Token = session.Token;
            updateSession.EmissionDate = session.EmissionDate;
            updateSession.RevocationDate = session.RevocationDate;
            updateSession.ExpirationDate = session.ExpirationDate;

            _sessionRepository.Update(updateSession);

            return new SessionDTO
            {
                Id = updateSession.Id,
                UserId = updateSession.UserId,
                Token = updateSession.Token,
                EmissionDate = updateSession.EmissionDate,
                RevocationDate = updateSession.RevocationDate,
                ExpirationDate = updateSession.ExpirationDate,
            };
        }

        public SessionDTO? Delete(int id)
        {
            var session = _sessionRepository.GetById(id);

            if(session == null) return null;

            _sessionRepository.Delete(id);

            return new SessionDTO
            {
                Id = session.Id,
                UserId = session.UserId,
                Token = session.Token,
                EmissionDate = session.EmissionDate,
                RevocationDate = session.RevocationDate,
                ExpirationDate = session.ExpirationDate,
            };
        }
    }
}
