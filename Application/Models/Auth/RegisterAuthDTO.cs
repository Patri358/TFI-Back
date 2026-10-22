using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Auth
{
    public class RegisterAuthDTO
    {
        public string Dni { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
    }
}