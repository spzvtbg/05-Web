namespace I.SimpleHandmadeFramework.Web
{
    using Server;
    using StandartRoutingDemo;
    using ViewEngine.StandartRouting.Handlers;

    public class Startup
    {
        public static void Main()
        {
            new HttpServerEngine(new HttpHandler(new AppConfig().Configure)).Run();
        }
    }
}
