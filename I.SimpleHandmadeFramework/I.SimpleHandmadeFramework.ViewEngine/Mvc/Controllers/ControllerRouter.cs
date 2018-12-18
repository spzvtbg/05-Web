namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Controllers
{
    using Server.Handlers.Contracts;
    using Server.Http.Contracts;

    public class ControllerRouter : IHandleable
    {
        //private readonly string appNameSpace;

        public ControllerRouter()
        {

        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            return null;
        }
    }
}
