using System;
using System.Collections.Generic;
using PowerDiaryChat.Services.Enums;
using PowerDiaryChat.Services.Model;

namespace PowerDiaryChat.Services.interfaces
{
    public interface IChatService
    {
        List<ChatModelDto> GetChats(DateTime date, GranularityLevel level);
    }
}