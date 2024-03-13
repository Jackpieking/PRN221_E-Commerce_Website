using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Implementations.Base;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;

namespace PRN221_E_Commerce_Website.Data.Repositories.Implementations;

public sealed class OrderDetailRepository :
    BaseRepository<OrderDetail>,
    IOrderDetailRepository
{
    public OrderDetailRepository(AppDbContext context) : base(context) { }
}
