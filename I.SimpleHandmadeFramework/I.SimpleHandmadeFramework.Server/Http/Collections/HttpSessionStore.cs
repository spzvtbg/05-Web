namespace I.SimpleHandmadeFramework.Server.Http.Collections
{
    using Contracts;
    using System.Collections.Concurrent;

    public static class HttpSessionStore
    {
        private static readonly ConcurrentDictionary<string, IHttpSession> sessions = new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession Get(string id)
        {
            return sessions.GetOrAdd(id, _ => new HttpSession(id));
        }
    }
}
