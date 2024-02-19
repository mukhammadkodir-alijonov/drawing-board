using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace DrawingBoard.Services
{
    public class DrawingHub : Hub
    {
        public async Task SendDrawing(string boardId, string type, string color, string content)
        {
            // Broadcast the drawing to all clients viewing the same board
            await Clients.Group(boardId).SendAsync("ReceiveDrawing", type, color, content);
        }

        public override async Task OnConnectedAsync()
        {
            // Add the client to a group based on the board they're viewing
            var boardId = Context.GetHttpContext().Request.Query["boardId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, boardId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Remove the client from the group when they disconnect
            var boardId = Context.GetHttpContext().Request.Query["boardId"];
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, boardId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
