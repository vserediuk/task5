using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using task5.Data;
using Microsoft.AspNetCore.Authentication;
using task5.Data.Models;

namespace task5.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task AuthUserAsync(HttpContext context, string userName)
        {
            _userRepo.Sign(userName);
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userName)
                    };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
        public bool IsAuthenticated(HttpContext context) => context.User.Identity.IsAuthenticated;
        public IEnumerable<User> GetUsers() => _userRepo.GetUsers();
        public IEnumerable<Message> GetUserMessages(HttpContext context) => _userRepo.GetUserMessages(context.User.Identity.Name);
        public void SendMessage(string username, string message, string title)
        {
            var user = _userRepo.GetUserByName(username);
            var msg = new Message() { SentTime = DateTime.Now.ToString(), Body = message,  Title = title,UserId = user.Id };
            _userRepo.AddMessage(msg);
        }

        public string GetUserName(int id) => _userRepo.GetUsers().First(user => user.Id == id).Name;
    }
}

