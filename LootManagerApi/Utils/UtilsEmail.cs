using System.ComponentModel.DataAnnotations;

namespace LootManagerApi.Utils
{
    public class UtilsEmail
    {
        public static bool IsValidateEmailAddressAttribute(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (!new EmailAddressAttribute().IsValid(email))
                return false;

            int atIndex = email.IndexOf("@");
            if (atIndex < 0 || atIndex == email.Length - 1)
                return false;

            string domain = email.Substring(atIndex + 1);
            if (domain.StartsWith(".") || domain.EndsWith("."))
                return false;

            if (domain.IndexOf(".") < 0)
                return false;

            return true;
        }
    }
}
