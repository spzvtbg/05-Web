namespace I.SimpleHandmadeFramework.Server.Handlers.Contracts
{
    using Http.Contracts;

    public interface IHandleable
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}
