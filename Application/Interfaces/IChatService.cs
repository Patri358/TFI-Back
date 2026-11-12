using Application.Models.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IChatService
    {
        public Task<List<ChatDTO>> GetAllAsync();
        public Task<ChatDTO?> GetByIdAsync(int id);
        public Task<List<ChatDTO>> GetByClientIdAsync(int clientId);
        public Task<List<ChatDTO>> GetByRecepcionistIdAsync(int receptionistId);
        public Task<ChatDTO?> AddAsync(CreateChatDTO chat);
        public Task<ChatDTO?> UpdateAsync(ChatDTO chat);
        public Task<ChatDTO?> DeleteAsync(int id);
    }
}