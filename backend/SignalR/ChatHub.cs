using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
    public class ChatHub : Hub
    {
        // Appelé quand un client envoie un message
        public async Task SendMessageToChannel(Guid channelId, string userName, string message)
        {
            await Clients.Group(channelId.ToString())
                         .SendAsync("ReceiveMessage", new {
                             ChannelId = channelId,
                             UserName = userName,
                             Content = message,
                             SentAt = DateTime.UtcNow
                         });
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinChannel(Guid channelId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, channelId.ToString());
        }

        public async Task LeaveChannel(Guid channelId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, channelId.ToString());
        }
    }
}
