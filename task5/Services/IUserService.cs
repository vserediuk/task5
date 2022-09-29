using task5.Data.Models;

namespace task5.Services
{
    public interface IUserService
    {
        Task AuthUserAsync(HttpContext context, string userName);
        IEnumerable<Message> GetUserMessages(HttpContext context);
        IEnumerable<User> GetUsers();
        bool IsAuthenticated(HttpContext context);
        void SendMessage(string username, string message, string title);
        string GetUserName(int id);
    }
}