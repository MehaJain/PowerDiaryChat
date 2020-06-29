using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerDiaryChat.Data;

namespace PowerDiaryChat.DB
{
    public interface IChatRepo
    {
        IEnumerable<Chat> GetChats(DateTime date);
    }
}
