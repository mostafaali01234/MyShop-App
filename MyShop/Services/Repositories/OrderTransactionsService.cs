using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class OrderTransactionsService : IOrderTransactionsService
    {
        private readonly ApplicationDbContext _context;

        public OrderTransactionsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OrdersTransaction> Add(OrdersTransaction OrdersTransaction)
        {
            await _context.AddAsync(OrdersTransaction);
            _context.SaveChanges();

            return OrdersTransaction;
        }

        public OrdersTransaction Delete(OrdersTransaction OrdersTransaction)
        {
            _context.Remove(OrdersTransaction);
            _context.SaveChanges();

            return OrdersTransaction;
        }

        public async Task<IEnumerable<OrdersTransaction>> GetAll()
        {
            return await _context.OrdersTransactions.OrderBy(x => x.Register_Date).ToListAsync();
        }

        public async Task<OrdersTransaction> GetById(byte id)
        {
            return await _context.OrdersTransactions.SingleOrDefaultAsync(g => g.Id == id);
        }

        public OrdersTransaction Update(OrdersTransaction OrdersTransaction)
        {
            _context.Update(OrdersTransaction);
            _context.SaveChanges();

            return OrdersTransaction;
        }
    }
}
