using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;
        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Chat> GetAll()
        {
            return _context.Chats;
        }

        public Chat? GetById(int id)
        {
            var chat = _context.Chats.FirstOrDefault(c => c.Id == id);
            if (chat == null) return null;

            return chat;
        }

        public Chat Add(Chat chat)
        {
            _context.Chats.Add(chat);
            return chat;
        }

        public Chat Update(Chat chat)
        {
            var index = _context.Chats.FindIndex(c => c.Id == chat.Id);
            if (index == -1) return chat;

            _context.Chats[index] = chat;
            return chat;
        }

        public Chat? Delete(int id)
        {
            var chat = GetById(id);
            if (chat == null) return null;

            _context.Chats.Remove(chat);
            return chat;
        }
    }
}
