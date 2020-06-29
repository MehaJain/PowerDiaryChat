using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerDiaryChat.Data
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public ChatType ChatEvent { get; set; }

        public DateTime ChatDateTime { get; set; }

        public override string ToString()
        {
            switch (ChatEvent)
            {
                case ChatType.Enters:
                {
                    return User?.UserName + " enters the room";
                }
                case ChatType.Leaves:
                {
                    return User?.UserName + " leaves";
                }
            }

            return base.ToString();
        }
    }
}
