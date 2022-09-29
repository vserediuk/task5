using System.Linq;
using task5.Data.Models;

namespace task5.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly Task5DbContext _db;
        public UserRepo(Task5DbContext db)
        {
            _db = db;
        }
        public void Sign(string username)
        {
            if(GetUserByName(username) == null) 
            { 
                _db.Add(new User { Name = username });
                _db.SaveChanges();
            }
        }

        public User GetUserByName(string username) => _db.Users.Where(user => user.Name == username).FirstOrDefault();

        public void AddMessage(Message message)
        {
            _db.Messages.Add(message);
            _db.SaveChanges();
        }

        public IEnumerable<User> GetUsers() => _db.Users;

        public IEnumerable<Message> GetUserMessages(string username)
        {
            var user = GetUserByName(username);
            return _db.Messages.Where(msg => msg.UserId == user.Id).AsEnumerable();
        }
    }
}
