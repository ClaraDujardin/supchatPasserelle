using Microsoft.AspNetCore.SignalR;
using Backend.SignalR;

namespace Backend.Services
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string userId, string message);
    }

    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(string userId, string message)
        {
            await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", message);
        }
    }
}
