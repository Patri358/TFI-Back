using Application.Models.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IChatService
    {
        public List<ChatDTO> GetAll();
        public ChatDTO? GetById(int id);
        public ChatDTO? Add(CreateChatDTO chat);
        public ChatDTO? Update(ChatDTO chat);
        public ChatDTO? Delete(int id);
    }
}
