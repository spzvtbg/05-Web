namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting.Contracts
{
    using Server.Http.Enums;
    using System.Collections.Generic;

    public interface IServerRouteConfig
    {
        IDictionary<HttpMethod, IDictionary<string, IRoutingContext>> Routes { get; }
    }
}
