using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using aspnetegitim.Data;
using aspnetegitim.Models;

namespace aspnetegitim.Services;

public class UserService
{
    private readonly AppDbContext _db;
    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public User? GetByUserName(string userName)
    {
        return _db.Set<User>().FirstOrDefault(u => u.UserName == userName);
    }

    public User Create(string userName, string password)
    {
        // generate salt
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = HashPassword(password, salt);
        var user = new User
        {
            UserName = userName,
            PasswordSalt = Convert.ToBase64String(salt),
            PasswordHash = Convert.ToBase64String(hash),
            CreatedAt = DateTime.UtcNow
        };
        _db.Set<User>().Add(user);
        _db.SaveChanges();
        return user;
    }

    public bool ValidateCredentials(string userName, string password)
    {
        var user = GetByUserName(userName);
        if (user == null) return false;
        var salt = Convert.FromBase64String(user.PasswordSalt);
        var expected = Convert.FromBase64String(user.PasswordHash);
        var actual = HashPassword(password, salt);
        return CryptographicOperations.FixedTimeEquals(expected, actual);
    }

    private static byte[] HashPassword(string password, byte[] salt)
    {
        // PBKDF2 with HMACSHA256
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100_000, HashAlgorithmName.SHA256);
        return pbkdf2.GetBytes(32);
    }
}
