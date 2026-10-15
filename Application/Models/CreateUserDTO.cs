using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class CreateUserDTO
    {
        public string Dni { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    }
}
