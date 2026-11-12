using Application.Interfaces;
using Application.Models.Chat;
using Application.Models.Message;
using Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<List<ChatDTO>> GetAllAsync()
        {
            var chats = await _chatRepository.GetAllAsync();
            return chats.Select(c => new ChatDTO
            {
                Id = c.Id,
                ClientId = c.ClientId,
                ReceptionistId = c.ReceptionistId,
                Status = c.Status,
                CreationDate = c.CreationDate,
                Messages = c.Messages.Select(m => new MessageDTO
                {
                    Id = m.Id,
                    ChatId = m.ChatId,
                    SendHour = m.SendHour,
                    Text = m.Text,
                }).ToList()
            }).ToList();
        }

        public async Task<ChatDTO?> GetByIdAsync(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);

            if (chat == null) return null;

            return new ChatDTO
            {
                Id = chat.Id,
                ClientId = chat.ClientId,
                ReceptionistId = chat.ReceptionistId,
                Status = chat.Status,
                CreationDate = chat.CreationDate,
                Messages = chat.Messages.Select(m => new MessageDTO
                {
                    Id = m.Id,
                    ChatId = m.ChatId,
                    SendHour = m.SendHour,
                    Text = m.Text
                }).ToList()
            };
        }

        public async Task<List<ChatDTO>> GetByClientIdAsync(int clientId)
        {
            var chats = await _chatRepository.GetByClientIdAsync(clientId);
            return chats.Select(c => new ChatDTO
            {
                Id = c.Id,
                ClientId = c.ClientId,
                ReceptionistId = c.ReceptionistId,
                Status = c.Status,
                CreationDate = c.CreationDate,
                Messages = c.Messages.Select(m => new MessageDTO
                {
                    Id = m.Id,
                    ChatId = m.ChatId,
                    SendHour = m.SendHour,
                    Text = m.Text
                }).ToList()
            }).ToList();
        }

        public async Task<List<ChatDTO>> GetByRecepcionistIdAsync(int receptionistId)
        {
            var chats = await _chatRepository.GetByRecepcionistIdAsync(receptionistId);
            return chats.Select(c => new ChatDTO
            {
                Id = c.Id,
                ClientId = c.ClientId,
                ReceptionistId = c.ReceptionistId,
                Status = c.Status,
                CreationDate = c.CreationDate,
                Messages = c.Messages.Select(m => new MessageDTO
                {
                    Id = m.Id,
                    ChatId = m.ChatId,
                    SendHour = m.SendHour,
                    Text = m.Text
                }).ToList()
            }).ToList();
        }

        public async Task<ChatDTO?> AddAsync(CreateChatDTO chat)
        {
            if (chat == null) return null;

            var newChat = new Chat
            {
                ClientId = chat.ClientId,
                ReceptionistId = chat.ReceptionistId,
                Status = ChatStatus.Activo,
                CreationDate = DateTime.Now,
                Messages = new List<Message>()
            };

            var addedChat = await _chatRepository.AddAsync(newChat);
            if (addedChat == null || addedChat.Id == 0) return null;
            await _chatRepository.SaveChangesAsync();

            return new ChatDTO
            {
                Id = addedChat.Id,
                ClientId = addedChat.ClientId,
                ReceptionistId = addedChat.ReceptionistId,
                Status = addedChat.Status,
                CreationDate = addedChat.CreationDate,
                Messages = new List<MessageDTO>()
            };
        }

        public async Task<ChatDTO?> UpdateAsync(ChatDTO chat)
        {
            var updateChat = await _chatRepository.GetByIdAsync(chat.Id);
            if (updateChat == null) return null;

            updateChat.ClientId = chat.ClientId;
            updateChat.ReceptionistId = chat.ReceptionistId;
            updateChat.Status = chat.Status;
            updateChat.Messages = chat.Messages.Select(m => new Message
            {
                SendHour = m.SendHour,
                Text = m.Text,
            }).ToList();

            await _chatRepository.UpdateAsync(updateChat);
            await _chatRepository.SaveChangesAsync();

            var newChatDTO = new ChatDTO
            {
                Id = updateChat.Id,
                ClientId = updateChat.ClientId,
                ReceptionistId = updateChat.ReceptionistId,
                Status = updateChat.Status,
                CreationDate = updateChat.CreationDate,
                Messages = updateChat.Messages.Select(m => new MessageDTO
                {
                    Id = m.Id,
                    ChatId = m.ChatId,
                    SendHour = m.SendHour,
                    Text = m.Text,
                }).ToList()
            };

            return newChatDTO;
        }

        public async Task<ChatDTO?> DeleteAsync(int id)
        {
            var chat = await _chatRepository.GetByIdAsync(id);
            if (chat == null) return null;

            await _chatRepository.DeleteAsync(id);
            await _chatRepository.SaveChangesAsync();

            return new ChatDTO
            {
                Id = chat.Id,
                ClientId = chat.ClientId,
                ReceptionistId = chat.ReceptionistId,
                Status = chat.Status,
                CreationDate = chat.CreationDate,
                Messages = chat.Messages.Select(m => new MessageDTO
                {
                    Id = m.Id,
                    ChatId = m.ChatId,
                    Text = m.Text,
                    SendHour = m.SendHour,
                }).ToList()
            };
        }
    }
}