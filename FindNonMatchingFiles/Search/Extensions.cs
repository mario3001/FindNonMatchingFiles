namespace FindNonMatchingFiles.Search
{
    public static class Extensions
    {
        public static bool IsDefault<T>(this T value) where T : struct
        {
            var isDefault = value.Equals(default(T));

            return isDefault;
        }
    }
}
