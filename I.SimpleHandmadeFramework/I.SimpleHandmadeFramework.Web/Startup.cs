namespace I.SimpleHandmadeFramework.Web
{
    using ViewEngine.MvcBasics;
    using ViewEngine.MvcBasics.Controllers;
    using Server;
    using StandartRoutingDemo;
    using ViewEngine.StandartRouting.Handlers;
    using System;

    public class Startup
    {
        public static void Main()
        {
            // STANDART SERVER ROUTING ...
            //new HttpServerEngine(new HttpHandler(new AppConfig().Configure)).Run();

            // MVC BASICS ROUTING ...
            new MvcEngine(new HttpServerEngine(new ControllerRouter())).Run();
        }
    }
}
