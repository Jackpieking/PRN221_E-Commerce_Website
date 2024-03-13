using Microsoft.EntityFrameworkCore;
using MockProject.Data.Repositories.Implementations.Base;
using MockProject.Data.Repositories.Interfaces;
using MockProject.Models;

namespace MockProject.Data.Repositories.Implementations;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    public RoomRepository(AppDbContext context)
        : base(context: context) { }

    public async Task<IEnumerable<Room>> GetAllRoomsVer1Async()
    {
        return await _entities
            .AsNoTracking()
            .Select(
                room =>
                    new Room
                    {
                        Id = room.Id,
                        Name = room.Name,
                        Price = room.Price,
                        RoomImage = room.RoomImage,
                        Category = new()
                        {
                            CategoryName = room.Category.CategoryName,
                            Description = room.Category.Description
                        }
                    }
            )
            .ToListAsync();
    }

    public async Task<Room> GetRoomById(int Id)
    {
        return await _entities
            .AsNoTracking()
            .Where(room => room.Id == Id)
            .Select(
                room =>
                    new Room
                    {
                        Name = room.Name,
                        Price = room.Price,
                        BedQuantity = room.BedQuantity,
                        RoomImage = room.RoomImage,
                        isAvailable = room.isAvailable,
                        Category = new() { CategoryName = room.Category.CategoryName },
                    }
            )
            .FirstOrDefaultAsync();
    }

    public Task<Room> GetRoomsByName(string RoomName)
    {
        throw new NotImplementedException();
    }
}
