namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting.Handlers
{
    using Server.Common;
    using Server.Handlers.Contracts;
    using Server.Http.Collections;
    using Server.Http.Contracts;
    using Server.Http.Headers;
    using System;

    public abstract class RequestHandler : IHandleable
    {
        private readonly Func<IHttpRequest, IHttpResponse> handler;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> handler)
        {
            this.handler = handler.EnsureNotNull() as Func<IHttpRequest, IHttpResponse>;
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            var newSessionId = string.Empty;

            if (!request.Cookies.Has($"{Stringifier.SID}"))
            {
                newSessionId = Guid.NewGuid().ToString();
                request.Session = HttpSessionStore.Get(newSessionId);
            }

            var response = this.handler(request);

            foreach (var cookie in request.Cookies)
            {
                if (cookie.IsNew)
                {
                    response.Headers.Add(new HttpHeader("Set-Cookie", cookie.ToString()));
                }
            }

            if (!response.Headers.Has("Content-Type"))
            {
                response.Headers.Add(new HttpHeader("Content-Type", "text/html"));
            }

            if (!string.IsNullOrWhiteSpace(newSessionId))
            {
                response.Headers.Add(new HttpHeader("Set-Cookie", $"{Stringifier.SID}={newSessionId}; HttpOnly; path=/"));
            }

            return response;
        }
    }
}
