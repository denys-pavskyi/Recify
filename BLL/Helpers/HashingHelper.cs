using System.Security.Cryptography;

namespace BLL.Helpers;

public static class HashingHelper
{
    public static string HashUsingPbkdf2(string password, string salt)
    {
        using var bytes = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256);
        var derivedRandomKey = bytes.GetBytes(32);
        var hash = Convert.ToBase64String(derivedRandomKey);
        return hash;
    }

    public static string CreateBase64Secret(int size)
    {
        var key = new byte[size];
        RandomNumberGenerator.Create().GetBytes(key);
        var secret = Convert.ToBase64String(key);

        return secret;
    }
}