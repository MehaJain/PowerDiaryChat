using System.ComponentModel.DataAnnotations;

namespace PowerDiaryChat.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}