namespace I.SimpleHandmadeFramework.Server.Http.Collections
{
    using Common;
    using Contracts;
    using Headers.Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HttpCookieCollection : HttpCollection<string, IHttpCookie>, IHttpCookieCollection
    {
        public IHttpCookie this[string key]
        {
            get
            {
                if (!this.Has(key))
                {
                    return null;
                }

                return this.Collection[key];
            }
        }

        public bool Any
        {
            get
            {
                return this.Collection.Count > 0;
            }
        }

        public void Add(IHttpCookie cookie)
        {
            if (!this.Has(cookie.Key))
            {
                this.Collection[cookie.Key] = cookie;
            }
        }

        public bool Has(string key)
        {
            return this.Collection.ContainsKey(key.EnsureNotNullOrEmpty());
        }

        public override string ToString()
        {
            return string.Join("; ", this.Collection.Values.Select(c => c.ToString()));
        }

        public IEnumerator<IHttpCookie> GetEnumerator()
        {
            return this.Collection.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Collection.Values.GetEnumerator();
        }
    }
}
