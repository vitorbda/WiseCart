using WiseCart.Domain.Entities;

namespace WiseCart.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string email);
    }
}
