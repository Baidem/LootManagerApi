namespace LootManagerApi.Utils
{
    public static class UtilsPassword
    {
        public static bool CheckPasswordMatchesHash(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        public static string GenerateHashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
