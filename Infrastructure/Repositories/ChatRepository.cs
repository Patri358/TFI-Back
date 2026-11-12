using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;
        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chat>> GetAllAsync()
        {
            return await _context.Chats
                .Include(c => c.Messages)
                .ToListAsync();
        }

        public async Task <Chat?> GetByIdAsync(int id)
        {
            return await _context.Chats
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        
        public async Task<List<Chat>> GetByClientIdAsync(int clientId)
        {
            return await _context.Chats
                .Include(c => c.Messages)
                .Where(c => c.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<List<Chat>> GetByRecepcionistIdAsync(int receptionistId)
        {
            return await _context.Chats
                .Include(c => c.Messages)
                .Where(c => c.ReceptionistId == receptionistId)
                .ToListAsync();
        }

        public async Task<Chat?> AddAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
            return chat;
        }

        public async Task<Chat?> UpdateAsync(Chat chat)
        {
            if (chat == null) return null;

            _context.Chats.Update(chat);
            return chat;
        }

        public async Task<Chat?> DeleteAsync(int id)
        {
            var chat = await GetByIdAsync(id);
            if (chat == null) return null;

            _context.Chats.Remove(chat);
            return chat;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}