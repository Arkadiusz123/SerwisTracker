namespace SerwisTracker.Server.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            var words = str.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 1)
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                else
                    words[i] = words[i].ToUpper();
            }
            return string.Join(' ', words);
        }
    }
}
