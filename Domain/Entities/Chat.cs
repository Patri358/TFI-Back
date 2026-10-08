using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RecepcionistId { get; set; }
        public string State { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }

    }
}
