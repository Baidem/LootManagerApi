namespace LootManagerApi.Exceptions
{
    public class LegacyOfLocationException : Exception
    {
        public LegacyOfLocationException()
        {
        }

        public LegacyOfLocationException(string? message) : base($"There is an error of the legacy of location. {message}")
        {
        }
    }
}