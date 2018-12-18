namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting.Handlers
{
    using Server.Http.Contracts;
    using System;

    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> handler) : base(handler)
        {
        }
    }
}
