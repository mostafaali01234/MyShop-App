using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<OrderDetails> Add(OrderDetails OrderDetail)
        {
            await _context.AddAsync(OrderDetail);
            _context.SaveChanges();

            return OrderDetail;
        }

        public OrderDetails Delete(OrderDetails OrderDetail)
        {
            _context.Remove(OrderDetail);
            _context.SaveChanges();

            return OrderDetail;
        }

        public async Task<IEnumerable<OrderDetails>> GetAll()
        {
            return await _context.OrderDetails.OrderBy(x => x.Register_Date).ToListAsync();
        }

        public async Task<OrderDetails> GetById(byte id)
        {
            return await _context.OrderDetails.SingleOrDefaultAsync(g => g.Id == id);
        }

        public OrderDetails Update(OrderDetails OrderDetail)
        {
            _context.Update(OrderDetail);
            _context.SaveChanges();

            return OrderDetail;
        }
    }
}
