namespace WiseCart.Domain.Interfaces.Services
{
    public interface ISecurityService
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string hash);
    }
}
