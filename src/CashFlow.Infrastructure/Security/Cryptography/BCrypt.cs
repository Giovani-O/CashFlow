using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncrypter
{
    public string Encrypt(string password)
    {
        // Criptografa a senha com BCrypt.Net-Next
        string passwordHash =  BC.HashPassword(password);
        
        return passwordHash;
    }

    public bool Verify(string password, string passwordHash)
    {
        // Verifica se a senha pode gerar o hash
        // Isso é usado para autenticação, uma vez que não é possível descriptografar
        // uma senha gerada com BCrypt, e sempre é gerado um hash diferente.
        return BC.Verify(password, passwordHash);
    }
}