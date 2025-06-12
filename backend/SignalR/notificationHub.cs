using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Backend.SignalR
{
    public class NotificationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                Groups.AddToGroupAsync(Context.ConnectionId, $"user:{userId}");
                Console.WriteLine($"Utilisateur connecté à NotificationHub : {userId}");
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null)
            {
                Groups.RemoveFromGroupAsync(Context.ConnectionId, $"user:{userId}");
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
