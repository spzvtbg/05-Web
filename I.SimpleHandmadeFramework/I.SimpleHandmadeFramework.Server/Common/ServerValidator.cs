namespace I.SimpleHandmadeFramework.Server.Common
{
    using System;

    public static class ServerValidator
    {
        public const string EmptyValue = "Null or empty value detected.";
        public const string NullableValue = "Object not set to a instance.";

        public static string EnsureNotNullOrEmpty(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception(EmptyValue);
            }

            return value;
        }

        public static Template EnsureNotNull<Template>(this Template value)
        {
            if (value == null)
            {
                throw new Exception(NullableValue);
            }

            return value;
        }
    }
}






























//            var row = Environment.StackTrace
//                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
//                    .FirstOrDefault(x => !x.Contains(nameof(ServerValidator)) && !x.Contains(nameof(Environment)))
//                    .Split(new[] { "at ", " in ", ".cs:line " }, StringSplitOptions.RemoveEmptyEntries);

//            var message = $@"
//SERVER EXCEPTION
//=======================================
//MESSAGE: Null or Empty string detected.
//LOCATOIN: {row[1]}
//LINE: {row[3]}";
