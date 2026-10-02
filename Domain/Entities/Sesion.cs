using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    internal class Sesion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string EmissionDate { get; set; } = string.Empty;
        public string RevocationDate { get; set; } = string.Empty;
        public string ExpirationDate { get; set; } = string.Empty;
    }
}
