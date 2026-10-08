using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
