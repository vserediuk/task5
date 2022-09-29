using Microsoft.AspNetCore.SignalR;
using task5.Data.Models;
using task5.Services;

public class ChatHub : Hub
{
    private readonly IUserService _userService;
    public ChatHub(IUserService userService)
    {
        _userService = userService;
    }
    public override Task OnConnectedAsync()
    {
        Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
        return base.OnConnectedAsync();
    }
    public async Task SendMessage(string message, string user)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public Task SendMessageToGroup(string sender, string receiver, string message)
    {
        return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
    }
}
