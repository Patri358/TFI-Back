using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Chat
{
    public class CreateChatDTO
    {
        public int ClientId { get; set; }
        public int ReceptionistId { get; set; }
    }
}