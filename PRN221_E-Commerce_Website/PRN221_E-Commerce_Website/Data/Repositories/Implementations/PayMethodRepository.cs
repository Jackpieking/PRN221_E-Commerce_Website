using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Implementations.Base;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;

namespace PRN221_E_Commerce_Website.Data.Repositories.Implementations;

public sealed class PayMethodRepository :
    BaseRepository<PayMethod>,
    IPayMethodRepository
{
    public PayMethodRepository(AppDbContext context) : base(context) { }
}
