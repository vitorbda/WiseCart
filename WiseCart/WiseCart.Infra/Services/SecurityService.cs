using WiseCart.Domain.Interfaces.Services;

namespace WiseCart.Infra.Services
{
    public class SecurityService : ISecurityService
    {
        public string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
