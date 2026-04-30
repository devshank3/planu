using Microsoft.AspNetCore.SignalR;
using planuApp.Models;
using planuApp.Services;

namespace planuApp.Hubs
{
    public class PokerHub : Hub
    {
        private readonly RoomStateManager _roomManager;

        public PokerHub(RoomStateManager roomManager)
        {
            _roomManager = roomManager;
        }

        public async Task CreateRoom(string roomId, string playerName, string cardSeriesType)
        {
            var room = _roomManager.CreateRoom(roomId, Context.ConnectionId, cardSeriesType);
            
            var player = new Player
            {
                ConnectionId = Context.ConnectionId,
                Name = playerName,
                IsModerator = true
            };
            
            room.Players.Add(player);
            _roomManager.UpdateRoom(room);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Caller.SendAsync("RoomJoined", room);
            await Clients.Group(roomId).SendAsync("RoomUpdated", room);
        }

        public async Task JoinRoom(string roomId, string playerName)
        {
            var room = _roomManager.GetRoom(roomId);
            if (room == null)
            {
                await Clients.Caller.SendAsync("Error", "Room not found.");
                return;
            }

            // Check if player already exists by connection ID (reconnect logic could go here)
            var existingPlayer = room.Players.FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
            if (existingPlayer == null)
            {
                var player = new Player
                {
                    ConnectionId = Context.ConnectionId,
                    Name = playerName,
                    IsModerator = false
                };
                room.Players.Add(player);
                _roomManager.UpdateRoom(room);
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            await Clients.Caller.SendAsync("RoomJoined", room);
            await Clients.Group(roomId).SendAsync("RoomUpdated", room);
        }

        public async Task SelectCard(string roomId, string card)
        {
            var room = _roomManager.GetRoom(roomId);
            if (room != null)
            {
                var player = room.Players.FirstOrDefault(p => p.ConnectionId == Context.ConnectionId);
                if (player != null)
                {
                    player.SelectedCard = card;
                    _roomManager.UpdateRoom(room);
                    await Clients.Group(roomId).SendAsync("RoomUpdated", room);
                }
            }
        }

        public async Task RevealCards(string roomId)
        {
            var room = _roomManager.GetRoom(roomId);
            if (room != null)
            {
                // Check if user is moderator or if anyone can reveal
                if (!room.OnlyModeratorCanReveal || room.ModeratorId == Context.ConnectionId)
                {
                    room.CardsRevealed = true;
                    _roomManager.UpdateRoom(room);
                    await Clients.Group(roomId).SendAsync("RoomUpdated", room);
                }
            }
        }

        public async Task ResetGame(string roomId)
        {
            var room = _roomManager.GetRoom(roomId);
            if (room != null && room.ModeratorId == Context.ConnectionId)
            {
                room.CardsRevealed = false;
                foreach (var player in room.Players)
                {
                    player.SelectedCard = null;
                }
                _roomManager.UpdateRoom(room);
                await Clients.Group(roomId).SendAsync("RoomUpdated", room);
            }
        }

        public async Task UpdateTopic(string roomId, string topic)
        {
            var room = _roomManager.GetRoom(roomId);
            if (room != null && room.ModeratorId == Context.ConnectionId)
            {
                room.Topic = topic;
                _roomManager.UpdateRoom(room);
                await Clients.Group(roomId).SendAsync("RoomUpdated", room);
            }
        }
        
        public async Task ChangeSettings(string roomId, string cardSeriesType, bool onlyModeratorCanReveal)
        {
            var room = _roomManager.GetRoom(roomId);
            if (room != null && room.ModeratorId == Context.ConnectionId)
            {
                room.CardSeriesType = cardSeriesType;
                room.OnlyModeratorCanReveal = onlyModeratorCanReveal;
                
                // Clear selected cards if series changes
                foreach (var player in room.Players)
                {
                    player.SelectedCard = null;
                }
                
                _roomManager.UpdateRoom(room);
                await Clients.Group(roomId).SendAsync("RoomUpdated", room);
            }
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Find room where user is a player and remove them or mark inactive
            // For simplicity in this prototype, we'll iterate all rooms.
            // In a real app, you'd map ConnectionId -> RoomId for faster lookup.
            // _roomManager.RemovePlayerFromRooms(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
