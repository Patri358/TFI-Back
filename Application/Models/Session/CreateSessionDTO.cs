using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Session
{
    public class CreateSessionDTO
    {
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
    }
}