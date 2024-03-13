using MockProject.Data.Repositories.Implementations.Base;
using MockProject.Data.Repositories.Interfaces;
using MockProject.Models;

namespace MockProject.Data.Repositories.Implementations
{
    public class PayMethodRepository : BaseRepository<PayMethod>, IPayMethodRepository
    {
        public PayMethodRepository(AppDbContext context)
            : base(context) { }
    }
}
