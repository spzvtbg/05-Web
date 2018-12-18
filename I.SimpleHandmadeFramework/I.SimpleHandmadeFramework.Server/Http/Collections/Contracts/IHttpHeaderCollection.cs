namespace I.SimpleHandmadeFramework.Server.Http.Collections.Contracts
{
    using Headers.Contracts;
    using System.Collections.Generic;

    public interface IHttpHeaderCollection
    {
        ICollection<IHttpHeader> this[string key] { get; }

        void Add(IHttpHeader header);

        bool Has(string key);
    }
}
