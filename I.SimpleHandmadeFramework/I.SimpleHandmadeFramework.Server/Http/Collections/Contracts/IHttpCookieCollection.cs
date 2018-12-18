namespace I.SimpleHandmadeFramework.Server.Http.Collections.Contracts
{
    using Headers.Contracts;
    using System.Collections.Generic;

    public interface IHttpCookieCollection : IEnumerable<IHttpCookie>
    {
        IHttpCookie this[string key] { get; }

        bool Any { get; }

        void Add(IHttpCookie header);

        bool Has(string key);
    }
}
