using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _context;

        public UsersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User User)
        {
            await _context.AddAsync(User);
            _context.SaveChanges();

            return User;
        }

        public User Delete(User User)
        {
            _context.Remove(User);
            _context.SaveChanges();

            return User;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.OrderBy(x => x.UserName).ToListAsync();
        }

        public async Task<User> GetById(byte id)
        {
            return await _context.Users.SingleOrDefaultAsync(g => g.Id == id);
        }

        public User Update(User User)
        {
            _context.Update(User);
            _context.SaveChanges();

            return User;
        }
    }
}
