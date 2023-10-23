namespace EFCore.Helpers;

public static class PasswordHash
{
    public static string GetHashCode(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        return BCrypt.Net.BCrypt.HashPassword(password, salt);
    }
}