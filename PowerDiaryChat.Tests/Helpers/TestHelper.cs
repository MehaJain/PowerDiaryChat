using System;
using PowerDiaryChat.Data;

namespace PowerDiaryChat.Tests.Helpers
{
    public static class TestHelper
    {
        public static User CreateUser(int id, string userName)
        {
            return new User()
            {
                Id = id,
                UserName = userName
            };
        }

        public static CommentChat CreatCommentChat(int id, string userName, string comments)
        {
            return new CommentChat()
            {
                Id = id,
                User = CreateUser(1, userName),
                ChatDateTime = DateTime.Today,
                ChatEvent = ChatType.Comments,
                Comment = comments
            };
        }

        public static HighFiveChat CreatHighFiveChat(int id, string userName, string highFivedUser)
        {
            return new HighFiveChat()
            {
                Id = id,
                User = CreateUser(1, userName),
                ChatDateTime = DateTime.Today,
                ChatEvent = ChatType.HighFive,
                HighFivedUser = CreateUser(2, highFivedUser)
            };
        }

        public static Chat CreatUserEntersChat(int id, string userName)
        {
            return new Chat()
            {
                Id = id,
                User = CreateUser(1, userName),
                ChatDateTime = DateTime.Today,
                ChatEvent = ChatType.Enters
            };
        }

        public static Chat CreatUserLeavesChat(int id, string userName)
        {
            return new Chat()
            {
                Id = id,
                User = CreateUser(1, userName),
                ChatDateTime = DateTime.Today,
                ChatEvent = ChatType.Leaves
            };
        }
    }
}
