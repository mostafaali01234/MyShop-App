using MyShop.Models;

namespace MyShop.Services
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetails>> GetAll();
        Task<OrderDetails> GetById(byte id);
        Task<OrderDetails> Add(OrderDetails OrderDetails);
        OrderDetails Update(OrderDetails OrderDetails);
        OrderDetails Delete(OrderDetails OrderDetails);
    }
}
