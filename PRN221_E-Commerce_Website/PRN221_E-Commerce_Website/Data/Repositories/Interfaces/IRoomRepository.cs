using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Interfaces;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<IEnumerable<Room>> GetAllRoomsVer1Async(CancellationToken cancellationToken);

    Task<Room> GetRoomByIdAsync(
        int Id,
        CancellationToken cancellationToken);

    Task<Room> GetRoomsByNameAsync(
        string roomName,
        CancellationToken cancellationToken);
}
