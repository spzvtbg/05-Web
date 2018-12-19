namespace I.SimpleHandmadeFramework.Web.StandartRoutingDemo
{
    using Server.Http.Contracts;
    using Server.Http.Responses;

    public class HomePage
    {
        public IHttpResponse Index()
        {
            return new HttpViewResponse("<h1>It works!</h1>");
        }

        public IHttpResponse Parameter(int number)
        {
            return new HttpViewResponse($"<h1>Parameter: {number}</h1>");
        }
    }
}
