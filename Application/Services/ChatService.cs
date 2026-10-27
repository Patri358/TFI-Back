using Application.Interfaces;
using Application.Models.Chat;
using Application.Models.Message;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public List<ChatDTO> GetAll()
        {
            var chats = _chatRepository.GetAll();
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

        public ChatDTO? GetById(int id)
        {
            var chat = _chatRepository.GetById(id);

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

        public ChatDTO? Add(CreateChatDTO chat)
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

            var addedChat = _chatRepository.Add(newChat);

            var newChatDTO = new ChatDTO
            {
                Id = addedChat.Id,
                ClientId = addedChat.ClientId,
                ReceptionistId = addedChat.ReceptionistId,
                Status = addedChat.Status,
                CreationDate = addedChat.CreationDate,
                Messages = new List<MessageDTO>()
            };

            return newChatDTO;
        }

        public ChatDTO? Update(ChatDTO chat)
        {
            var updateChat = _chatRepository.GetById(chat.Id);

            if (updateChat == null) return null;

            updateChat.ClientId = chat.ClientId;
            updateChat.ReceptionistId = chat.ReceptionistId;
            updateChat.Status = chat.Status;
            updateChat.Messages = chat.Messages.Select(m => new Message
            {
                SendHour = m.SendHour,
                Text = m.Text,
            }).ToList();

            _chatRepository.Update(updateChat);

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

        public ChatDTO? Delete(int id)
        {
            var chat = _chatRepository.GetById(id);

            if (chat == null) return null;

            _chatRepository.Delete(id);

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