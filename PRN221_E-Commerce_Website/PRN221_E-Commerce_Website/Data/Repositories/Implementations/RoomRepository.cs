using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Implementations.Base;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Implementations;

public sealed class RoomRepository :
    BaseRepository<Room>,
    IRoomRepository
{
    public RoomRepository(AppDbContext context) : base(context: context) { }

    public async Task<IEnumerable<Room>> GetAllRoomsVer1Async(CancellationToken cancellationToken)
    {
        return await _entities
            .AsNoTracking()
            .Select(room => new Room
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
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Room> GetRoomByIdAsync(
        int Id,
        CancellationToken cancellationToken)
    {
        return await _entities
            .AsNoTracking()
            .Where(room => room.Id == Id)
            .Select(room => new Room
            {
                Name = room.Name,
                Price = room.Price,
                BedQuantity = room.BedQuantity,
                RoomImage = room.RoomImage,
                IsAvailable = room.IsAvailable,
                Category = new()
                {
                    CategoryName = room.Category.CategoryName
                },
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<Room> GetRoomsByNameAsync(
        string roomName,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
