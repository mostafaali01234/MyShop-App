using MyShop.Models;

namespace MyShop.Services
{
    public interface IOrderTransactionsService
    {
        Task<IEnumerable<OrdersTransaction>> GetAll();
        Task<OrdersTransaction> GetById(byte id);
        Task<OrdersTransaction> Add(OrdersTransaction OrdersTransaction);
        OrdersTransaction Update(OrdersTransaction OrdersTransaction);
        OrdersTransaction Delete(OrdersTransaction OrdersTransaction);
    }
}
