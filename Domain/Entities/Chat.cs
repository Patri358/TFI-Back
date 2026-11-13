using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ReceptionistId { get; set; }
        public ChatStatus Status { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>(); 
    }

    public enum ChatStatus
    {
        Activo,
        Finalizado
    }
}