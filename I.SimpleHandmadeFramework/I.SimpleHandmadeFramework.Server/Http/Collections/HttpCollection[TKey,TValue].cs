namespace I.SimpleHandmadeFramework.Server.Http.Collections
{
    using System.Collections.Generic;

    public abstract class HttpCollection<TKey, TValue>
    {
        public HttpCollection()
        {
            this.Collection = new Dictionary<TKey, TValue>();
        }

        protected IDictionary<TKey, TValue> Collection { get; }
    }
}
