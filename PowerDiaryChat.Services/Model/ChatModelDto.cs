using System;
using System.Collections.Generic;
using System.Linq;
using PowerDiaryChat.Data;
using PowerDiaryChat.Services.Enums;

namespace PowerDiaryChat.Services.Model
{
    public class ChatModelDto
    {
        public GranularityLevel granularityLevel;
        public DateTime Key { get; set; }
        public List<Chat> Chats { get; set; }

        public ChatType ChatType { get; set; }

        public override string ToString()
        {
            if (granularityLevel == GranularityLevel.MinuteByMinute)
            {
                return Chats.FirstOrDefault()?.ToString()?? string.Empty;
            }

            switch (ChatType)
            {
                case ChatType.Enters:
                {
                    if (Chats.Count == 1)
                    {
                        return Chats.Count + " person entered";
                    }

                    return Chats.Count + " people entered";
                }
                    
                case ChatType.Leaves:
                {
                    if (Chats.Count == 1)
                    {
                        return Chats.Count + " person left";
                    }

                    return Chats.Count + " people left";
                }
                case ChatType.Comments:
                {
                    if (Chats.Count == 1)
                    {
                        return Chats.Count + " comment";
                    }

                    return Chats.Count + " comments";
                }
                case ChatType.HighFive:
                {
                    string value;

                    var highFiveUsers = Chats.Select(obj=>obj.UserId).Distinct().Count();

                    if (highFiveUsers == 1)
                    {
                        value = "1 person high-fived ";
                    }
                    else
                    {
                        value = highFiveUsers + " people high-fived ";
                    }

                    if (Chats.Count == 1)
                    {
                        value += Chats.Count + " other person";
                    }
                    else
                    {
                        value += Chats.Count + " other people";
                    }

                    return value;
                }
            }

            return base.ToString();
        }
    }
}