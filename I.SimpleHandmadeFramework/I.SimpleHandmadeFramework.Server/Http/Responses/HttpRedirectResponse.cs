namespace I.SimpleHandmadeFramework.Server.Http.Responses
{
    using Common;
    using Enums;
    using Headers;

    public class HttpRedirectResponse : HttpResponse
    {
        public HttpRedirectResponse(string redirectUrl) : base(HttpStatusCode._302_Found)
        {
            this.Headers.Add(new HttpHeader(Stringifier.Location, redirectUrl.EnsureNotNullOrEmpty()));
        }
    }
}
