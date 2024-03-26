using LearningProgramming.Application.Contracts.Binance;
using LearningProgramming.Application.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace LearningProgramming.Application.Hubs
{
    [Authorize]
    public class BinanceHub : Hub<IBinanceHubFunctions>
    {
        public static readonly Dictionary<string, string> ConnectedUsers = new Dictionary<string, string>();

        public BinanceHub()
        {

        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.GetUserId().ToString();
            string connectionId = Context.ConnectionId;
            if (!string.IsNullOrEmpty(userId) && !ConnectedUsers.ContainsKey(userId))
            {
                ConnectedUsers[userId] = connectionId;
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User.GetUserId().ToString();
            if (!string.IsNullOrEmpty(userId) && ConnectedUsers.ContainsKey(userId))
            {
                ConnectedUsers.Remove(userId);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
