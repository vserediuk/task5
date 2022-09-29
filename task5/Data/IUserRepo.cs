using task5.Data.Models;

namespace task5.Data
{
    public interface IUserRepo
    {
        void Sign(string username);
        User GetUserByName(string username);
        void AddMessage(Message message);
        IEnumerable<User> GetUsers();
        IEnumerable<Message> GetUserMessages(string user);
    }
}
