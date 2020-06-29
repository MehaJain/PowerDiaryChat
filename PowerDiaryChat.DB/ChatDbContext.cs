using System.Data.Entity;
using PowerDiaryChat.Data;

namespace PowerDiaryChat.DB
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext() : base("name=DefaultConnectionString")
        {
        }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<User> Users { get; set; }
    }
}