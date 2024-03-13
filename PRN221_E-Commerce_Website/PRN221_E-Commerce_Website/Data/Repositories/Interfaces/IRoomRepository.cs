using MockProject.Data.Repositories.Interfaces.Base;
using MockProject.Models;

namespace MockProject.Data.Repositories.Interfaces;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<IEnumerable<Room>> GetAllRoomsVer1Async();
    public Task<Room> GetRoomById(int Id);
    public Task<Room> GetRoomsByName(string RoomName);
}
