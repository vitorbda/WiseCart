using WiseCart.Application.DTOs;
using WiseCart.Application.Interfaces;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Domain.Interfaces.Services;

namespace WiseCart.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly ISecurityService _securityService;

        public UserService(IUnitOfWork uow, ISecurityService securityService)
        {
            _uow = uow;
            _securityService = securityService;
        }

        public async Task<bool> CreateUser(RegisterUserDTO register)
        {
            if (register.Password != register.ConfirmPassword)            
                return false;

            var hashedPassword = _securityService.EncryptPassword(register.Password);

            var userEntity = new User
            {
                Email = register.Email,
                UserName = register.UserName,
                Password = hashedPassword,
                Name = register.Name,
                Role = "User"
            };

            await _uow.UserRepository.CreateAsync(userEntity);
            await _uow.CommitAsync();

            return true;
        }
    }
}
