namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting.Handlers
{
    using Contracts;
    using Server.Handlers.Contracts;
    using Server.Http.Contracts;
    using Server.Http.Responses;
    using System.Text.RegularExpressions;

    public class HttpHandler : IHandleable
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IAppRouteConfig appRouteConfig)
        {
            this.serverRouteConfig = new ServerRouteConfig(appRouteConfig);
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var path = request.Path;
            var method = request.Method;
            var patternsWithHandlers = this.serverRouteConfig.Routes[method];
            var response = default(IHttpResponse);

            foreach (var patternWithHandler in patternsWithHandlers)
            {
                var pattern = patternWithHandler.Key;
                var routingContext = patternWithHandler.Value;
                var match = Regex.Match(path, pattern);

                if (!match.Success)
                {
                    continue;
                }

                foreach (var parameter in routingContext.Parameters)
                {
                    var parameterValue = match.Groups[parameter].Value;
                    request.UrlParameters.Add(parameter, parameterValue);
                }

                response = routingContext.Handler.Handle(request);
                break;
            }

            return response ?? new HttpNotFoundResponse("PAGE NOT FOUND");
        }
    }
}
