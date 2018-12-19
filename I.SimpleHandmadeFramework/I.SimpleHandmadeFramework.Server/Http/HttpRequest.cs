namespace I.SimpleHandmadeFramework.Server.Http
{
    using Collections;
    using Collections.Contracts;
    using Common;
    using Contracts;
    using Enums;
    using Headers;
    using System;
    using System.Net;

    public class HttpRequest : IHttpRequest
    {
        private readonly string requestText;
        private readonly string[] requestRows;

        public HttpRequest(string requestText)
        {
            this.requestText = requestText.EnsureNotNullOrEmpty();
            this.requestRows = this.requestText.SplitOf(Stringifier.None, Environment.NewLine);

            this.ParseHeaderRow();
            this.ParseQueryParameters();
            this.ParseUrlParameters();
            this.ParseHeaders();
            this.ParseCookie();
            this.ParseSession();
            this.ParseFormData();
        }

        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }

        public string Path { get; private set; }

        public string Query { get; private set; }

        public string Fragment { get; private set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public IHttpDataCollection QueryParameters { get; private set; }

        public IHttpDataCollection FormDataParameters { get; private set; }

        public IHttpDataCollection UrlParameters { get; private set; }

        public IHttpSession Session { get; set; }

        public override string ToString()
        {
            return this.requestText.Trim();
        }

        private void ParseHeaderRow()
        {
            var requestHeaderTokens = this.requestRows[0].SplitOf(Stringifier.Trim, Stringifier.Space);

            if (requestHeaderTokens.Length != 3 || requestHeaderTokens[2] != Stringifier.HttpVersion)
            {
                throw new Exception("Invalid requst header or http version.");
            }

            if (!Enum.TryParse(requestHeaderTokens[0], out HttpMethod method))
            {
                throw new Exception("Unavailable request method.");
            }

            this.Method = method;
            this.Url = requestHeaderTokens[1];
            this.Url.TrySplit(out string path, out string query, out string fragment, Stringifier.Trim, Stringifier.Question, Stringifier.Hashtag);
            this.Path = path;
            this.Query = query;
            this.Fragment = fragment;
        }

        private void ParseQueryParameters()
        {
            this.QueryParameters = new HttpDataCollection();

            if (string.IsNullOrEmpty(this.Query))
            {
                return;
            }

            this.Extract(WebUtility.UrlDecode(this.Query), this.QueryParameters);
        }

        private void ParseUrlParameters()
        {
            this.UrlParameters = new HttpDataCollection();
        }

        private void ParseHeaders()
        {
            this.Headers = new HttpHeaderCollection();

            for (int line = 1; line < this.requestRows.Length; line++)
            {
                var current = this.requestRows[line];

                if (string.IsNullOrEmpty(current))
                {
                    break;
                }

                if (current.TrySplit(out string key, out string value, Stringifier.Trim, Stringifier.Colon))
                {
                    this.Headers.Add(new HttpHeader(key, value));
                }
            }
        }

        private void ParseCookie()
        {
            this.Cookies = new HttpCookieCollection();

            if (!this.Headers.Has(Stringifier.Cookie))
            {
                return;
            }

            var cookies = this.Headers[Stringifier.Cookie];

            foreach (var cookie in cookies)
            {
                var cookieValues = cookie.Value.SplitOf(Stringifier.Trim, Stringifier.Semicolon);

                foreach (var cookieValue in cookieValues)
                {
                    if (cookieValue.TrySplit(out string key, out string value, Stringifier.Trim, Stringifier.Equals))
                    {
                        this.Cookies.Add(new HttpCookie(key, value));
                    }
                }
            }
        }

        private void ParseSession()
        {
            if (this.Cookies.Has(Stringifier.SID))
            {
                var cookie = this.Cookies[Stringifier.SID];

                this.Session = HttpSessionStore.Get(cookie.Value);
            }
        }

        private void ParseFormData()
        {
            this.FormDataParameters = new HttpDataCollection();

            if (this.Method != HttpMethod.POST)
            {
                return;
            }

            var dataIndex = Array.IndexOf(this.requestRows, string.Empty) + 1;

            this.Extract(WebUtility.UrlDecode(this.requestRows[dataIndex]), this.FormDataParameters);
        }

        private void Extract(string query, IHttpDataCollection queryParameters)
        {
            var parameters = query.SplitOf(Stringifier.Trim, Stringifier.Ampersant);

            foreach (var parameter in parameters)
            {
                if (parameter.TrySplit(out string key, out string value, Stringifier.Trim, Stringifier.Equals))
                {
                    queryParameters.Add(key, value);
                }
            }
        }
    }
}
