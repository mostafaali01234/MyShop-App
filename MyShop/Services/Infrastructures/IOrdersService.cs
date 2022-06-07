using MyShop.Models;

namespace MyShop.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(byte id);
        Task<Order> Add(Order Order);
        Order Update(Order Order);
        Order Delete(Order Order);
    }
}
