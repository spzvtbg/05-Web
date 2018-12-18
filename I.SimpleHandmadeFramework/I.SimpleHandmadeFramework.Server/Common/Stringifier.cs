namespace I.SimpleHandmadeFramework.Server.Common
{
    using System;

    public static class Stringifier
    {
        public const string Ampersant = "&";
        public const string Cookie = "Cookie";
        public const string Colon = ": ";
        public const string Dash = "_";
        new public const string Equals = "=";
        public const string Hashtag = "#";
        public const string HttpVersion = "HTTP/1.1";
        public const string Location = "Location";
        public const string Question = "?";
        public const string Semicolon = ";";
        public const string SID = "_I_S_I_D_";
        public const string Slash = "/";
        public const string Space = " ";

        public const StringSplitOptions None = StringSplitOptions.None;
        public const StringSplitOptions Trim = StringSplitOptions.RemoveEmptyEntries;

        public static string[] SplitOf(this string value, StringSplitOptions splitOptions, params string[] parameters)
        {
            return value.Split(parameters, splitOptions);
        }

        public static bool TrySplit(this string value, out string a, out string b, StringSplitOptions splitOptions, params string[] parameters)
        {
            a = b = string.Empty;

            var tokens = value.Split(parameters, splitOptions);
            var tokensLength = tokens.Length;

            if (tokensLength > 0)
            {
                a = tokens[0];
            }
            if (tokensLength > 1)
            {
                b = tokens[1];
            }

            return tokens.Length == 2;
        }

        public static void TrySplit(this string value, out string a, out string b, out string c, StringSplitOptions splitOptions, params string[] parameters)
        {
            a = b = c = string.Empty;

            var tokens = value.Split(parameters, splitOptions);
            var tokensLength = tokens.Length;

            if (tokensLength > 0)
            {
                a = tokens[0];
            }
            if (tokensLength > 1)
            {
                b = tokens[1];
            }
            if (tokensLength > 2)
            {
                c = tokens[2];
            }
        }
    }
}
