using MyShop.Models;

namespace MyShop.Services
{
    public interface IStatesService
    {
        Task<IEnumerable<State>> GetAll();
        Task<State> GetById(byte id);
        Task<State> Add(State State);
        State Update(State State);
        State Delete(State State);
    }
}
