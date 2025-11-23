using CardapioDigital.Domain.Entities;
using CardapioDigital.Domain.Interfaces;
using CardapioDigital.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db) => _db = db;

        public Task<Order?> GetByIdAsync(Guid id, CancellationToken ct)
            => _db.Orders.FirstOrDefaultAsync(o => o.Id == id, ct);

        public Task UpdateAsync(Order order, CancellationToken ct)
        {
            _db.Orders.Update(order);
            return _db.SaveChangesAsync(ct);
        }
    }

}
