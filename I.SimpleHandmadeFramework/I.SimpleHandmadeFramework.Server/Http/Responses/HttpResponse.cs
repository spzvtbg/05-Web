namespace I.SimpleHandmadeFramework.Server.Http.Responses
{
    using Collections;
    using Collections.Contracts;
    using Common;
    using Contracts;
    using Enums;
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
            var responseBuilder = new StringBuilder();

            responseBuilder.Append(Stringifier.HttpVersion);
            responseBuilder.Append(this.StatusCode.ToString());
            responseBuilder.Replace(Stringifier.Dash, Stringifier.Space);
            responseBuilder.AppendLine();
            responseBuilder.AppendLine(this.Headers.ToString());
            responseBuilder.AppendLine();
            responseBuilder.AppendLine(this.Content);

            return responseBuilder.ToString().Trim();
        }
    }
}
