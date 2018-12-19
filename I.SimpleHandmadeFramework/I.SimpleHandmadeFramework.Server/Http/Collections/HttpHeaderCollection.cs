namespace I.SimpleHandmadeFramework.Server.Http.Collections
{
    using Common;
    using Contracts;
    using Headers.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class HttpHeaderCollection : HttpCollection<string, ICollection<IHttpHeader>>, IHttpHeaderCollection
    {
        public ICollection<IHttpHeader> this[string key]
        {
            get
            {
                if (this.Has(key))
                {
                    return this.Collection[key];
                }

                return new List<IHttpHeader>();
            }
        }

        public void Add(IHttpHeader header)
        {
            if (!this.Has(header.Key))
            {
                this.Collection[header.Key] = new List<IHttpHeader>();
            }

            this.Collection[header.Key].Add(header);
        }

        public bool Has(string key)
        {
            return this.Collection.ContainsKey(key.EnsureNotNullOrEmpty());
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var headerCollection in this.Collection)
            {
                foreach (var header in headerCollection.Value)
                {
                    stringBuilder.AppendLine(header.ToString());
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
