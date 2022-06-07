using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ApplicationDbContext _context;

        public CartItemsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CartItem> Add(CartItem CartItem)
        {
            await _context.AddAsync(CartItem);
            _context.SaveChanges();

            return CartItem;
        }

        public CartItem Delete(CartItem CartItem)
        {
            _context.Remove(CartItem);
            _context.SaveChanges();

            return CartItem;
        }

        public async Task<IEnumerable<CartItem>> GetAll()
        {
            return await _context.CartItems.OrderBy(x => x.Register_Date).ToListAsync();
        }

        public async Task<CartItem> GetById(byte id)
        {
            return await _context.CartItems.SingleOrDefaultAsync(g => g.Id == id);
        }

        public CartItem Update(CartItem CartItem)
        {
            _context.Update(CartItem);
            _context.SaveChanges();

            return CartItem;
        }
    }
}
