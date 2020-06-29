using System;
using System.Collections.Generic;
using System.Linq;
using PowerDiaryChat.Data;
using PowerDiaryChat.DB;
using PowerDiaryChat.Services.Enums;
using PowerDiaryChat.Services.interfaces;
using PowerDiaryChat.Services.Model;

namespace PowerDiaryChat.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepo chatRepository;

        public ChatService(IChatRepo _chatRepository)
        {
            chatRepository = _chatRepository;
        }

        public List<ChatModelDto> GetChats(DateTime date, GranularityLevel level)
        {
            var chats = chatRepository.GetChats(date).GroupBy(obj =>
                {
                    var chatTime = obj.ChatDateTime;
                    chatTime = chatTime.AddMinutes(-(chatTime.Minute % ((int) level)));
                    chatTime = chatTime.AddMilliseconds(-chatTime.Millisecond - 1000 * chatTime.Second);
                    return chatTime;
                });

            List<ChatModelDto> modelDtos = new List<ChatModelDto>();

            foreach (var chat in chats)
            {
                var chatEvents = chat.GroupBy(obj => obj.ChatEvent);
                foreach (var chatEvent in chatEvents)
                {
                    var chatUsers = chatEvent.GroupBy(obj => obj.User).ToList();
                    var userChats = new List<Chat>();
                    foreach (var chatUser in chatUsers)
                    {
                        userChats.AddRange(chatUser.Select(obj => obj));
                    }
                    var chatDto = new ChatModelDto {granularityLevel = level, Key = chat.Key, ChatType = chatEvent.Key, Chats = userChats };
                    modelDtos.Add(chatDto);
                }
            }

            return modelDtos;
        }
    }
}