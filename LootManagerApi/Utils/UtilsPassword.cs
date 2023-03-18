namespace LootManagerApi.Utils
{
    public static class UtilsPassword
    {
        public const int PASSWORD_MIN_LENGTH = 8;
        public static bool CheckPasswordMatchesHash(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        public static string GenerateHashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool CheckPasswordLength(string password)
        {
            if (password.Length < PASSWORD_MIN_LENGTH)
                return true;
            else
                return false;
        }
        public static bool CheckPasswordComplexity(string password)
        {
            bool hasUpperCase = password.Any(c => char.IsUpper(c));
            bool hasLowerCase = password.Any(c => char.IsLower(c));
            bool hasDigit = password.Any(c => char.IsDigit(c));
            bool hasSpecialChar = password.Any(c => char.IsSymbol(c) || char.IsPunctuation(c));

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }



    }
}
