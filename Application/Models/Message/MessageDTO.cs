using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Message
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string SendHour { get; set; } = string.Empty;
    }
}