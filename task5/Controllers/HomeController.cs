using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Diagnostics;
using System.Reflection;
using task5.Data.Models;
using task5.Models;
using task5.Services;

namespace task5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new IndexModel(_userService));
        }

        [HttpPost]
        public async Task<IActionResult> Sign(string username)
        {
            await _userService.AuthUserAsync(HttpContext, username);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Send(string username, string message, string title)
        {
            _hubContext.Clients.Group(username).SendAsync("ReceiveMessage", HttpContext.User.Identity.Name, message);
            _userService.SendMessage(username, message, title); 
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}