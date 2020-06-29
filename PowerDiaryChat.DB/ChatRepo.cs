using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PowerDiaryChat.Data;

namespace PowerDiaryChat.DB
{
    public class ChatRepo: IChatRepo
    {
        private readonly ChatDbContext dbContext;

        public ChatRepo(ChatDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IEnumerable<Chat> GetChats(DateTime date)
        {
            return dbContext.Chats.Where(obj => obj.ChatDateTime <= date)
                .Include(obj => obj.User)
                .OrderBy(obj => obj.ChatDateTime)
                .AsEnumerable();
        }
    }
}
