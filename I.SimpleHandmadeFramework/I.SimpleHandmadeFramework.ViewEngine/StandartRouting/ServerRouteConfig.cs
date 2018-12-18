namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting
{
    using Contracts;
    using Server.Common;
    using Server.Http.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ServerRouteConfig : IServerRouteConfig
    {
        private readonly IDictionary<HttpMethod, IDictionary<string, IRoutingContext>> routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpMethod, IDictionary<string, IRoutingContext>>();

            var methods = Enum.GetValues(typeof(HttpMethod)).Cast<HttpMethod>();

            foreach (var method in methods)
            {
                this.routes[method] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeRouteConfig(appRouteConfig);
        }

        public IDictionary<HttpMethod, IDictionary<string, IRoutingContext>> Routes { get { return this.routes; } }

        private void InitializeRouteConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (var methodWhitRoutes in appRouteConfig.Routes)
            {
                var method = methodWhitRoutes.Key;

                foreach (var routeWithHandler in methodWhitRoutes.Value)
                {
                    var route = routeWithHandler.Key;
                    var handler = routeWithHandler.Value;
                    var parameters = new List<string>();
                    var routeRegex = this.ParseRoute(route, parameters);
                    var routingContext = new RoutingContext(handler, parameters);

                    this.routes[method][routeRegex] = routingContext;
                }
            }
        }

        private string ParseRoute(string route, ICollection<string> parameters)
        {
            var placeHolder = "/{0}";
            var regexBuilder = new StringBuilder($"^{placeHolder}$");

            var routeTokens = route.EnsureNotNullOrEmpty().SplitOf(Stringifier.Trim, Stringifier.Slash);
            var tokenPattern = "^[a-zA-Z]+$";
            var pattern = @"^\{(?<regex>(\(\?<(?<parameter>([a-zA-Z]+))>\S+\)))\}$";

            foreach (var token in routeTokens)
            {
                var newToken = token;
                var match = Regex.Match(newToken, pattern);

                if (match.Success)
                {
                    newToken = match.Groups["regex"].Value;
                    parameters.Add(match.Groups["parameter"].Value);
                }
                
                var tokenMatch = Regex.Match(newToken, tokenPattern);

                if (!tokenMatch.Success)
                {
                    throw new InvalidOperationException($"Invalid route parameter found in [ServerRouteConfig.ParseRoute(string route[{route}], ...)].");
                }

                regexBuilder.Replace(placeHolder, $"/{newToken}{placeHolder}");
            }

            if (routeTokens.Length == 0)
            {
                placeHolder = "{0}";
            }

            regexBuilder.Replace(placeHolder, string.Empty);
            return regexBuilder.ToString().Trim();
        }
    }
}
