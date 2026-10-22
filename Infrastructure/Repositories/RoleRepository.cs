using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Role> GetAll()
        {
            // Si todavía no tenés DbSet<Role> en el contexto, con esto al menos compila
            // Cuando lo agregues, cambiá por _context.Roles
            return new List<Role>();
        }

        public Role? GetById(int id)
        {
            return null;
        }

        public Role Add(Role entity)
        {
            return entity;
        }

        public Role Update(Role entity)
        {
            return entity;
        }

        public Role? Delete(int id)
        {
            return null;
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            if (string.Equals(name, "Cliente", StringComparison.OrdinalIgnoreCase))
                return new Role { Id = 1, Name = "Cliente" };

            return null;

        }

        public async Task<List<Role>> GetRolesByUserIdAsync(int userId)
        {
            await Task.CompletedTask;

            // Por ahora le asignamos "Cliente" por defecto para que el token
            // tenga el claim Role y funcione con [Authorize(Roles = "Cliente")]
            return new List<Role>
            {
                new Role { Id = 1, Name = "Cliente" }
            };
        }
    } 
}
