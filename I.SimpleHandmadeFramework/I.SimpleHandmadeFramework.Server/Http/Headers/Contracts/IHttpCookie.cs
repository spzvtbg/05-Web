namespace I.SimpleHandmadeFramework.Server.Http.Headers.Contracts
{
    using System;

    public interface IHttpCookie : IHttpHeader
    {
        DateTime Expires { get; }

        bool IsNew { get; }
    }
}
