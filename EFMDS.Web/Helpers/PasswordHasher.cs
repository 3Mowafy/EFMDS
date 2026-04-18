using System.Security.Cryptography;

public static class PasswordHasher
{
    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);

        using var sha256 = SHA256.Create();
        var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

        var saltedPassword = new byte[salt.Length + passwordBytes.Length];
        salt.CopyTo(saltedPassword, 0);
        passwordBytes.CopyTo(saltedPassword, salt.Length);

        var hashBytes = sha256.ComputeHash(saltedPassword);

        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hashBytes);
    }
    public static bool Verify(string password, string hash)
    {
        var parts = hash.Split(':');
        if (parts.Length != 2)
            return false;

        var salt = Convert.FromBase64String(parts[0]);
        var storedHash = Convert.FromBase64String(parts[1]);

        using var sha256 = SHA256.Create();
        var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

        var saltedPassword = new byte[salt.Length + passwordBytes.Length];
        salt.CopyTo(saltedPassword, 0);
        passwordBytes.CopyTo(saltedPassword, salt.Length);

        var computedHash = sha256.ComputeHash(saltedPassword);

        return computedHash.SequenceEqual(storedHash);
    }
}