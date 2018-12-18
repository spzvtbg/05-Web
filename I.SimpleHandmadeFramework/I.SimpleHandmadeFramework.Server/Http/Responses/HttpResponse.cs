namespace I.SimpleHandmadeFramework.Server.Http.Responses
{
    using Collections;
    using Collections.Contracts;
    using Common;
    using Contracts;
    using Enums;
    using Headers;
    using System.Text;

    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
        }

        protected string Content { get; set; }

        public HttpStatusCode StatusCode  { get; }

        public IHttpHeaderCollection Headers  { get; }

        public IHttpCookieCollection Cookies  { get; }

        public IHttpSession Session  { get; }

        public override string ToString()
        {
            this.Cookies.Add(new HttpCookie(Stringifier.SID, this.Session.Id));
            this.Headers.Add(new HttpHeader(Stringifier.Cookie, this.Cookies.ToString()));

            var responseBuilder = new StringBuilder();

            responseBuilder.AppendLine(Stringifier.HttpVersion);
            responseBuilder.AppendLine(this.StatusCode.ToString());
            responseBuilder.Replace(Stringifier.Dash, Stringifier.Space);
            responseBuilder.AppendLine(this.Headers.ToString());
            responseBuilder.AppendLine();
            responseBuilder.AppendLine(this.Content);

            return responseBuilder.ToString().Trim();
        }
    }
}
