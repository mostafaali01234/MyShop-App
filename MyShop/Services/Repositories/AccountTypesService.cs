using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class AccountTypesService : IAccountTypesService
    {
        private readonly ApplicationDbContext _context;

        public AccountTypesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AccountTypes> Add(AccountTypes AccountType)
        {
            await _context.AddAsync(AccountType);
            _context.SaveChanges();

            return AccountType;
        }

        public AccountTypes Delete(AccountTypes AccountType)
        {
            _context.Remove(AccountType);
            _context.SaveChanges();

            return AccountType;
        }

        public async Task<IEnumerable<AccountTypes>> GetAll()
        {
            return await _context.AccountTypes.OrderBy(x => x.TypeName).ToListAsync();
        }

        public async Task<AccountTypes> GetById(byte id)
        {
            return await _context.AccountTypes.SingleOrDefaultAsync(g => g.Id == id);
        }

        public AccountTypes Update(AccountTypes AccountType)
        {
            _context.Update(AccountType);
            _context.SaveChanges();

            return AccountType;
        }
    }
}
