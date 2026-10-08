using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Sesion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime EmissionDate { get; set; }
        public DateTime RevocationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
