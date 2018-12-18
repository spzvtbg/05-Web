namespace I.SimpleHandmadeFramework.Server.Http.Headers
{
    using Common;
    using Contracts;

    public class HttpHeader : IHttpHeader
    {
        public HttpHeader(string key, string value)
        {
            this.Key = key.EnsureNotNullOrEmpty();
            this.Value = value.EnsureNotNullOrEmpty();
        }

        public string Key { get; }

        public string Value { get; }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
