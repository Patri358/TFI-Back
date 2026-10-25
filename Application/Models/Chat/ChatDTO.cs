using Application.Models.Message;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Chat
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ReceptionistId { get; set; }
        public ChatStatus Status { get; set; }
        public DateTime CreationDate { get; set; }

        // 1:n
        public List<MessageDTO> Messages { get; set; } = [];
    }
}