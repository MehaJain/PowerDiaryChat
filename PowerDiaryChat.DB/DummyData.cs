using System;
using System.Collections.Generic;
using System.Linq;
using PowerDiaryChat.Data;

namespace PowerDiaryChat.DB
{
    public class DummyData
    {
        public static void Initialize(ChatDbContext dbContext)
        {
            if (dbContext.Chats.Any())
            {
                return;   // DB has already been seeded
            }

            var users = GetUsers();
            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();

            AddChats(dbContext);
            dbContext.SaveChanges();
        }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    UserName = "Bob"
                },
                new User()
                {
                    UserName = "Kate"
                },
                new User()
                {
                    UserName = "James"
                },
                new User()
                {
                    UserName = "Andy"
                },
                new User()
                {
                    UserName = "Molly"
                },
            };
            return users;
        }

        public static void AddChats(ChatDbContext context )
        {
            List<Chat> chats = new List<Chat>()
            {
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Kate"),
                    ChatEvent = ChatType.Enters,
                    ChatDateTime = GetDateTime(-10, 17, 00)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Bob"),
                    ChatEvent = ChatType.Enters,
                    ChatDateTime = GetDateTime(-10, 17, 10)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                    ChatEvent = ChatType.Enters,
                    ChatDateTime = GetDateTime(-10, 17, 25)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Andy"),
                    ChatEvent = ChatType.Enters,
                    ChatDateTime = GetDateTime(-10, 17, 40)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Molly"),
                    ChatEvent = ChatType.Enters,
                    ChatDateTime = GetDateTime(-10, 17, 55)
                },
                new CommentChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Bob"),
                    ChatEvent = ChatType.Comments,
                    ChatDateTime = GetDateTime(-10, 17, 20),
                    Comment = "Hello everyone!"
                },
                new CommentChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Kate"),
                    ChatEvent = ChatType.Comments,
                    ChatDateTime = GetDateTime(-10, 17, 35),
                    Comment = "Hey Bob!"
                },
                new CommentChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                    ChatEvent = ChatType.Comments,
                    ChatDateTime = GetDateTime(-10, 18, 00),
                    Comment = "Good Bye!"

                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Bob"),
                    ChatEvent = ChatType.Leaves,
                    ChatDateTime = GetDateTime(-10, 19, 06)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                    ChatEvent = ChatType.Leaves,
                    ChatDateTime = GetDateTime(-10, 19, 15)
                },
                new HighFiveChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Bob"),
                    ChatEvent = ChatType.HighFive,
                    ChatDateTime = GetDateTime(-10, 18, 07),
                    HighFivedUser = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                },
                new CommentChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Andy"),
                    ChatEvent = ChatType.Comments,
                    ChatDateTime = GetDateTime(-10, 19, 27),
                    Comment = "Have a great weekend!"
                },
                new CommentChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Molly"),
                    ChatEvent = ChatType.Comments,
                    ChatDateTime = GetDateTime(-10, 19, 40),
                    Comment = "Build successfully Created"
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Bob"),
                    ChatEvent = ChatType.Enters,
                    ChatDateTime = GetDateTime(-10, 19, 56)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                    ChatEvent = ChatType.Enters,
                    ChatDateTime = GetDateTime(-10, 20, 06)
                },
                new HighFiveChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Kate"),
                    ChatEvent = ChatType.HighFive,
                    ChatDateTime = GetDateTime(-10, 21, 25),
                    HighFivedUser = context.Users.FirstOrDefault(obj => obj.UserName == "Molly"),
                },
                new HighFiveChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Kate"),
                    ChatEvent = ChatType.HighFive,
                    ChatDateTime = GetDateTime(-10, 21, 55),
                    HighFivedUser = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                },
                new HighFiveChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                    ChatEvent = ChatType.HighFive,
                    ChatDateTime = GetDateTime(-10, 22, 02),
                    HighFivedUser = context.Users.FirstOrDefault(obj => obj.UserName == "Andy"),

                },
                new HighFiveChat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Andy"),
                    ChatEvent = ChatType.HighFive,
                    ChatDateTime = GetDateTime(-10, 22, 40),
                    HighFivedUser = context.Users.FirstOrDefault(obj => obj.UserName == "Molly"),
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Bob"),
                    ChatEvent = ChatType.Leaves,
                    ChatDateTime = GetDateTime(-10, 23, 06)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "James"),
                    ChatEvent = ChatType.Leaves,
                    ChatDateTime = GetDateTime(-10, 23, 35)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Kate"),
                    ChatEvent = ChatType.Leaves,
                    ChatDateTime = GetDateTime(-10, 23, 05)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Andy"),
                    ChatEvent = ChatType.Leaves,
                    ChatDateTime = GetDateTime(-10, 23, 10)
                },
                new Chat()
                {
                    User = context.Users.FirstOrDefault(obj => obj.UserName == "Molly"),
                    ChatEvent = ChatType.Leaves,
                    ChatDateTime = GetDateTime(-10, 23, 20)
                }
            };

            context.Chats.AddRange(chats);
            context.SaveChanges();
        }

        public static DateTime GetDateTime(int days, double hours, double minutes)
        {
            return DateTime.Today.AddDays(days).AddHours(hours).AddMinutes(minutes);
        }
    }
}
