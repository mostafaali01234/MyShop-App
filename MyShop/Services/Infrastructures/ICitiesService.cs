using MyShop.Models;

namespace MyShop.Services
{
    public interface ICitiesService
    {
        Task<IEnumerable<City>> GetAll();
        Task<City> GetById(byte id);
        Task<City> Add(City City);
        City Update(City City);
        City Delete(City City);
    }
}
