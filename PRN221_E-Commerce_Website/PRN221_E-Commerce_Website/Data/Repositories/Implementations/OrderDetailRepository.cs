using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockProject.Data.Repositories.Implementations.Base;
using MockProject.Data.Repositories.Interfaces;
using MockProject.Models;

namespace MockProject.Data.Repositories.Implementations
{
    public sealed class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContext context)
            : base(context) { }
    }
}
