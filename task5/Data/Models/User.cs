namespace task5.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Message>? Messages { get; set; }
    }
}
