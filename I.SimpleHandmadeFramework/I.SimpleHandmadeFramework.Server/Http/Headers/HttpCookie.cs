namespace I.SimpleHandmadeFramework.Server.Http.Headers
{
    using System;
    using Contracts;

    public class HttpCookie : HttpHeader, IHttpCookie
    {
        private const int expireDays = 3;

        public HttpCookie(string key, string value, bool isNew = false, int expireDays = expireDays) 
            : base(key, value)
        {
            this.IsNew = isNew;
            this.Expires = DateTime.UtcNow.AddDays(expireDays);
        }

        public DateTime Expires  { get; }

        public bool IsNew  { get; }

        public override string ToString()
        {
            return $"{this.Key}={this.Value} {nameof(this.Expires)}={this.Expires}";
        }
    }
}
