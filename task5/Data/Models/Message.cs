using System.ComponentModel.DataAnnotations.Schema;

namespace task5.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SentTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
