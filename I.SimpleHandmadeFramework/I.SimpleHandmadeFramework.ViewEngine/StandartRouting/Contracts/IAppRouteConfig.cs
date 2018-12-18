namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting.Contracts
{
    using Server.Handlers.Contracts;
    using Server.Http.Contracts;
    using Server.Http.Enums;
    using System;
    using System.Collections.Generic;

    public interface IAppRouteConfig
    {
        IDictionary<HttpMethod, IDictionary<string, IHandleable>> Routes { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, IHandleable handler);
    }
}
