namespace I.SimpleHandmadeFramework.Web.StandartRoutingDemo
{
    using Server.Http.Contracts;
    using Server.Http.Responses;
    using System;

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

        public IHttpResponse Form()
        {
            return new HttpViewResponse(@"<h1>Search form</h1>
<form method=""post"">
    <label for=""search"">Search term: </label>
    <input id=""search"" type=""text"" name=""searchTerm""/>
    <input type=""submit"" value=""Search""/>
</form>");
        }

        public IHttpResponse Form(string searchTerm)
        {
            return new HttpViewResponse($"<h1>Search Term: {searchTerm}</h1>");
        }

        public IHttpResponse Testsession(IHttpRequest request)
        {
            const string date = "date";
            var session = request.Session;

            if (session[date] == null)
            {
                session.Add(date, DateTime.UtcNow.ToLongTimeString());
            }
            
            return new HttpViewResponse($"<h1>Session date: {session[date]}</h1>");
        }
    }
}
