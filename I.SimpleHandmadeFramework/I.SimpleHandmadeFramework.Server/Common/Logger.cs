namespace I.SimpleHandmadeFramework.Server.Common
{
    using System;

    public class Logger
    {
        public static void Log(string header, string content = "")
        {
            var headerFrame = $"{new string('=', 100)}";
            var tempHeader = $"= {string.Join(' ', header.ToUpper().ToCharArray())} ";
            var outputHeader = $"{tempHeader}{new string('=', Math.Abs(100 - tempHeader.Length))}";

            Console.WriteLine();
            Console.WriteLine(headerFrame);
            Console.WriteLine(outputHeader);
            Console.WriteLine(headerFrame);

            if (!string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine();
                Console.WriteLine(content);
            }
        }
    }
}
