namespace I.SimpleHandmadeFramework.Server.Http.Responses
{
    using Enums;

    public class HttpViewResponse : HttpResponse
    {
        public HttpViewResponse(string content) : base(HttpStatusCode._200_OK)
        {
            this.Content = content;
        }
    }
}
