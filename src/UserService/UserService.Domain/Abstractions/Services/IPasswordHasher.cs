namespace UserService.Domain.Abstractions.Services;

public interface IPasswordHasher
{
    string HashPassword(string password);
}
