using System.Security.Cryptography;
using System.Text;
using UserService.Domain.Abstractions.Services;

namespace UserService.Domain.Services._Auth_;

internal class PasswordHasher(SHA256 sha) : IPasswordHasher
{
    public string HashPassword(string password)
    {
        var bytes = Encoding.Unicode.GetBytes(password);

        var result = sha.ComputeHash(bytes);

        var hash = Encoding.Unicode.GetString(result);

        return hash;
    }
}
