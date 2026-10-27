using Application.Models.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISessionService
    {
        public List<SessionDTO> GetAll();
        public SessionDTO? GetById(int id);
        public SessionDTO Add(CreateSessionDTO session);
        public SessionDTO? Update(SessionDTO session);
        public SessionDTO? Delete(int id);
    }
}
