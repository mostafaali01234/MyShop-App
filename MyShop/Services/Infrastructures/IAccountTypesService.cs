using MyShop.Models;

namespace MyShop.Services
{
    public interface IAccountTypesService
    {
        Task<IEnumerable<AccountTypes>> GetAll();
        Task<AccountTypes> GetById(byte id);
        Task<AccountTypes> Add(AccountTypes AccountType);
        AccountTypes Update(AccountTypes AccountType);
        AccountTypes Delete(AccountTypes AccountType);
    }
}
