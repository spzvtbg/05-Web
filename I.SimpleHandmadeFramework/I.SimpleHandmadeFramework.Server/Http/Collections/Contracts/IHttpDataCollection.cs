namespace I.SimpleHandmadeFramework.Server.Http.Collections.Contracts
{
    public interface IHttpDataCollection
    {
        string this[string key] { get; }

        void Add(string key, string value);
    }
}
