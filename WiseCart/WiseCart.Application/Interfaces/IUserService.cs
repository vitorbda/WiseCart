using WiseCart.Application.DTOs;

namespace WiseCart.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(RegisterUserDTO register);
    }
}
