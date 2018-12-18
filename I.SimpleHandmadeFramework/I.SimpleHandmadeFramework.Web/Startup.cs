using System.IO;

namespace I.SimpleHandmadeFramework.Web
{
    public class Startup
    {
        public static void Main()
        {
            var html = File.ReadAllText("../../../Demo.html");
            System.Console.WriteLine(html);
        }
    }
}
