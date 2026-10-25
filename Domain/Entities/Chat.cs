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
        public ChatStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public enum ChatStatus
    {
        Activo,
        Finalizado
    }
}
