using System.ComponentModel.DataAnnotations.Schema;

namespace PowerDiaryChat.Data
{
    [Table("HighFiveChat")]
    public class HighFiveChat : Chat
    {
        [ForeignKey("User")]
        public int? HighFivedUserId { get; set; }
        public User HighFivedUser { get; set; }

        public override string ToString()
        {
            return User?.UserName + " high-fives " + HighFivedUser?.UserName;
        }
    }
}