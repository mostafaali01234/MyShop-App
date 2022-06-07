using MyShop.Models;

namespace MyShop.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(byte id);
        Task<User> Add(User User);
        User Update(User User);
        User Delete(User User);
    }
}
