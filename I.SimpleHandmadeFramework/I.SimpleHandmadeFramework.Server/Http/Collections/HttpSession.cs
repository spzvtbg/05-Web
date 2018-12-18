namespace I.SimpleHandmadeFramework.Server.Http.Collections
{
    using Common;
    using Contracts;

    public class HttpSession : HttpCollection<string, object>, IHttpSession
    {
        public HttpSession(string id) : base()
        {
            this.Id = id.EnsureNotNullOrEmpty();
        }

        public string Id { get; }

        public object this[string key]
        {
            get
            {
                if (!this.Collection.ContainsKey(key.EnsureNotNullOrEmpty()))
                {
                    return null;
                }

                return this.Collection[key];
            }
        }

        public void Add(string key, object value)
        {
            if (!this.Collection.ContainsKey(key.EnsureNotNullOrEmpty()))
            {
                this.Collection[key] = new object { };
            }

            this.Collection[key] = value.EnsureNotNull();
        }

        public void Clear()
        {
            this.Collection.Clear();
        }
    }
}
