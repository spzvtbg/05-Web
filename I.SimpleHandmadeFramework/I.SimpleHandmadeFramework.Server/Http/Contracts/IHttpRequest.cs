namespace I.SimpleHandmadeFramework.Server.Http.Contracts
{
    using Collections.Contracts;
    using Enums;

    public interface IHttpRequest
    {
        HttpMethod Method  { get; }

        string Url  { get; }

        string Path  { get; }

        string Query  { get; }

        string Fragment  { get; }

        IHttpHeaderCollection Headers  { get; }

        IHttpCookieCollection Cookies  { get; }

        IHttpDataCollection QueryParameters  { get; }

        IHttpDataCollection FormDataParameters  { get; }

        IHttpDataCollection UrlParameters  { get; }

        IHttpSession Session  { get; set; }
    }
}
