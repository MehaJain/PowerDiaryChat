using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerDiaryChat.Data
{
    [Table("CommentChat")]
    public class CommentChat : Chat
    {
        public string Comment { get; set; }
        public override string ToString()
        {
            return User?.UserName + " comments: \"" + Comment + "\"";
        }
    }
}