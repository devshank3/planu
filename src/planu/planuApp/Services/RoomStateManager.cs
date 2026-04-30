using System.Collections.Concurrent;
using planuApp.Models;

namespace planuApp.Services
{
    public class RoomStateManager
    {
        private readonly ConcurrentDictionary<string, Room> _rooms = new();

        public Room? GetRoom(string roomId)
        {
            _rooms.TryGetValue(roomId, out var room);
            return room;
        }

        public Room CreateRoom(string roomId, string moderatorId, string cardSeriesType, bool onlyModeratorCanReveal = false)
        {
            var room = new Room
            {
                RoomId = roomId,
                ModeratorId = moderatorId,
                CardSeriesType = cardSeriesType,
                OnlyModeratorCanReveal = onlyModeratorCanReveal
            };
            
            _rooms.TryAdd(roomId, room);
            return room;
        }

        public bool RemoveRoom(string roomId)
        {
            return _rooms.TryRemove(roomId, out _);
        }
        
        public void UpdateRoom(Room room)
        {
            _rooms.AddOrUpdate(room.RoomId, room, (key, oldValue) => room);
        }
    }
}
