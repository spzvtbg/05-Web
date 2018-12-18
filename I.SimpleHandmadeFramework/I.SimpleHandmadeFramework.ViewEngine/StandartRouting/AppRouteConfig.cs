namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting
{
    using Contracts;
    using Handlers;
    using Server.Common;
    using Server.Handlers.Contracts;
    using Server.Http.Contracts;
    using Server.Http.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppRouteConfig : IAppRouteConfig
    {
        private readonly Dictionary<HttpMethod, IDictionary<string, IHandleable>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpMethod, IDictionary<string, IHandleable>>();

            var methods = Enum.GetValues(typeof(HttpMethod)).Cast<HttpMethod>();

            foreach (var method in methods)
            {
                this.routes[method] = new Dictionary<string, IHandleable>();
            }
        }

        public IDictionary<HttpMethod, IDictionary<string, IHandleable>> Routes { get { return this.routes; } }

        public void Get(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, new GetHandler(handler));
        }

        public void Post(string route, Func<IHttpRequest, IHttpResponse> handler)
        {
            this.AddRoute(route, new PostHandler(handler));
        }

        public void AddRoute(string route, IHandleable handler)
        {
            handler = handler.EnsureNotNull();

            var handlerMethod = handler.GetType().Name.Replace("Handler", string.Empty);

            if (!Enum.TryParse(handlerMethod, true, out HttpMethod method))
            {
                throw new InvalidOperationException("Invalid handler providet.");
            }

            if (this.routes.ContainsKey(method))
            {
                this.routes[method][route] = handler;
            }
        }
    }
}
