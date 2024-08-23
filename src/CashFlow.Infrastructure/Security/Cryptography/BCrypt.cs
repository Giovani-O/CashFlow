using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        // Criptografa a senha com BCrypt.Net-Next
        string passwordHash =  BC.HashPassword(password);

        return passwordHash;
    }
}