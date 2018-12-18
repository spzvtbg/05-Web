namespace I.SimpleHandmadeFramework.Server.Http.Responses
{
    using Enums;

    public class HttpNotFoundResponse : HttpResponse
    {
        public HttpNotFoundResponse(string content) : base(HttpStatusCode._404_Not_Found)
        {
            this.Content = content;
        }
    }
}
