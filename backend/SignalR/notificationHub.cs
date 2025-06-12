using Microsoft.AspNetCore.SignalR;

namespace Backend.SignalR
{
    public class NotificationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connecté : {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
    }
}
