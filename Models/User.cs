using System;

namespace aspnetegitim.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    // Base64-encoded hash and salt
    public string PasswordHash { get; set; } = string.Empty;
    public string PasswordSalt { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
