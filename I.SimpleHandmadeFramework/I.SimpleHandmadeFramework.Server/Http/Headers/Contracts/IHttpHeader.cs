namespace I.SimpleHandmadeFramework.Server.Http.Headers.Contracts
{
    public interface IHttpHeader
    {
        string Key { get; }

        string Value { get; }
    }
}
