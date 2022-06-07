using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext _context;

        public OrdersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> Add(Order Order)
        {
            await _context.AddAsync(Order);
            _context.SaveChanges();

            return Order;
        }

        public Order Delete(Order Order)
        {
            _context.Remove(Order);
            _context.SaveChanges();

            return Order;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.OrderBy(x => x.Register_Date).ToListAsync();
        }

        public async Task<Order> GetById(byte id)
        {
            return await _context.Orders.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Order Update(Order Order)
        {
            _context.Update(Order);
            _context.SaveChanges();

            return Order;
        }
    }
}
