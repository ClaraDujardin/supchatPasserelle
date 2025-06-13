using Microsoft.AspNetCore.SignalR;
using Backend.Data;
using Backend.Models;

using Backend.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public interface INotificationService
    {
        Task SendAsync(Guid userId, string type, string content);
        Task<IEnumerable<Notification>> GetForUser(Guid userId);
        Task MarkAsReadAsync(Guid notificationId);
    }

    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(ApplicationDbContext context, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task SendAsync(Guid userId, string type, string content)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Type = type,
                Content = content,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.Group($"user:{userId}")
                .SendAsync("ReceiveNotification", new
                {
                    notification.Id,
                    notification.Type,
                    notification.Content,
                    notification.IsRead,
                    notification.CreatedAt
                });
        }

        public async Task<IEnumerable<Notification>> GetForUser(Guid userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task MarkAsReadAsync(Guid notificationId)
        {
            var notif = await _context.Notifications.FindAsync(notificationId);
            if (notif == null) return;

            notif.IsRead = true;
            await _context.SaveChangesAsync();
        }
    }
}
