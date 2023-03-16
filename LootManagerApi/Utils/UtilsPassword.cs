namespace LootManagerApi.Utils
{
    public class UtilsPassword
    {
        public static bool CheckPasswordMatchesHash(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

    }
}
