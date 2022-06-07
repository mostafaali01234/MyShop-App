using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class CartsService : ICartsService
    {
        private readonly ApplicationDbContext _context;

        public CartsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cart> Add(Cart Cart)
        {
            await _context.AddAsync(Cart);
            _context.SaveChanges();

            return Cart;
        }

        public Cart Delete(Cart Cart)
        {
            _context.Remove(Cart);
            _context.SaveChanges();

            return Cart;
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _context.Carts.OrderBy(x => x.Register_Date).ToListAsync();
        }

        public async Task<Cart> GetById(byte id)
        {
            return await _context.Carts.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Cart Update(Cart Cart)
        {
            _context.Update(Cart);
            _context.SaveChanges();

            return Cart;
        }
    }
}
