namespace I.SimpleHandmadeFramework.Server.Http.Collections
{
    using Common;
    using Contracts;

    public class HttpDataCollection : HttpCollection<string, string>, IHttpDataCollection
    {
        public string this[string key]
        {
            get
            {
                if (this.Has(key))
                {
                    return this.Collection[key];
                }

                return string.Empty;
            }
        }

        public void Add(string key, string value)
        {
            if (!this.Has(key))
            {
                this.Collection[key] = string.Empty;
            }

            this.Collection[key] = value;
        }

        private bool Has(string key)
        {
            return this.Collection.ContainsKey(key.EnsureNotNullOrEmpty());
        }
    }
}
