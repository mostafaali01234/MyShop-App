using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly ApplicationDbContext _context;

        public CitiesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<City> Add(City City)
        {
            await _context.AddAsync(City);
            _context.SaveChanges();

            return City;
        }

        public City Delete(City City)
        {
            _context.Remove(City);
            _context.SaveChanges();

            return City;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Cities.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<City> GetById(byte id)
        {
            return await _context.Cities.SingleOrDefaultAsync(g => g.Id == id);
        }

        public City Update(City City)
        {
            _context.Update(City);
            _context.SaveChanges();

            return City;
        }
    }
}
