using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string SendHour { get; set; } = string.Empty;
    }
}
