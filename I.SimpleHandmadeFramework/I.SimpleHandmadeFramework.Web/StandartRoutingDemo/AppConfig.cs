namespace I.SimpleHandmadeFramework.Web.StandartRoutingDemo
{
    using ViewEngine.StandartRouting;
    using ViewEngine.StandartRouting.Contracts;

    public class AppConfig
    {
        private readonly IAppRouteConfig configuration;

        public AppConfig()
        {
            this.configuration = new AppRouteConfig();
        }

        public IAppRouteConfig Configure
        {
            get
            {
                this.configuration.Get("/", request => new HomePage().Index());

                this.configuration
                    .Get("/parameter/{(?<number>[0-9]*)}", request => new HomePage()
                        .Parameter(int.Parse(request.UrlParameters["number"])));

                return this.configuration;
            }
        }
    }
}
