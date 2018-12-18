namespace I.SimpleHandmadeFramework.Server.Http.Collections.Contracts
{
    public interface IHttpSession
    {
        string Id { get; }

        object this[string key] { get; }

        void Add(string key, object value);

        void Clear();
    }
}
