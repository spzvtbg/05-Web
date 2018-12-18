namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting.Handlers
{
    using Server.Http.Contracts;
    using System;

    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> handler) : base(handler)
        {
        }
    }
}
