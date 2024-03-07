using LearningProgramming.Application.Contracts.Logging;
using Microsoft.AspNetCore.SignalR;

namespace LearningProgramming.Application.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub(IAppLogger<ChatHub> appLogger)
        {
            appLogger.LogInformation("Chat hub created");
        }

        public async Task SendMessage(long username, string message) =>
            await Clients.All.SendAsync("ReceiveMessage", username, message);

        public async Task SendMessageFromClient(string connectionId, long username, string message) =>
           await Clients.Client(connectionId).SendAsync("ReceiveMessage", username, message);

        public async Task SendMessageToGroup(string group, long username, string message) =>
            await Clients.Group(group).SendAsync("ReceiveMessage", username, message);

        public async Task AddGroupAsync(string connectionId, string group) => await Groups.AddToGroupAsync(connectionId, group);
    }
}

// Calling to client outside of hubs
// IHubContext<ChatHub> contextHub inject constructor to use
// Hub will create when you connection and destroy as long as signalr is done it