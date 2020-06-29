using System;
using System.Collections.Generic;
using PowerDiaryChat.Data;
using PowerDiaryChat.DB;
using PowerDiaryChat.Tests.Helpers;

namespace PowerDiaryChat.Tests.Moq
{
    public class MoqChatRepository: IChatRepo
    {
        public IEnumerable<Chat> GetChats(DateTime date)
        {
            return ChatTestData.GetChats();
        }
    }
}
