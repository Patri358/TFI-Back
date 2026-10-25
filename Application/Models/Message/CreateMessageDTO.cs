using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Message
{
    public class CreateMessageDTO
    {
        public int ChatId { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}