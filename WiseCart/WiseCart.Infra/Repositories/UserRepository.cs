using Microsoft.EntityFrameworkCore;
using WiseCart.Domain.Entities;
using WiseCart.Domain.Interfaces;
using WiseCart.Infra.Context;

namespace WiseCart.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
