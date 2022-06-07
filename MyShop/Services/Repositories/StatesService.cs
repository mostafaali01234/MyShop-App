using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class StatesService : IStatesService
    {
        private readonly ApplicationDbContext _context;

        public StatesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<State> Add(State State)
        {
            await _context.AddAsync(State);
            _context.SaveChanges();

            return State;
        }

        public State Delete(State State)
        {
            _context.Remove(State);
            _context.SaveChanges();

            return State;
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            return await _context.States.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<State> GetById(byte id)
        {
            return await _context.States.SingleOrDefaultAsync(g => g.Id == id);
        }

        public State Update(State State)
        {
            _context.Update(State);
            _context.SaveChanges();

            return State;
        }
    }
}
