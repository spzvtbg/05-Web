namespace I.SimpleHandmadeFramework.Server.Handlers
{
    using Common;
    using Contracts;
    using Http;
    using Http.Contracts;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    internal class ConnectionHandler : IConnectionHandler
    {
        private readonly Socket client;
        private readonly IHandleable handler;

        public ConnectionHandler(Socket client, IHandleable handler)
        {
            this.client = client;
            this.handler = handler;
        }

        public async Task ProcessRequestAsync()
        {
            var request = await this.ReadRequest();

            if (request != null)
            {
                var response = this.handler.Handle(request);
                var responseBytes = Encoding.UTF8.GetBytes(response.ToString());
                var byteSegments = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegments, SocketFlags.None);

                Logger.Log(nameof(request), request.ToString());
                Logger.Log(nameof(response), response.ToString());
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var requestBuilder = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                var bytesCount = await this.client.ReceiveAsync(data, SocketFlags.None);
                var textSegment = Encoding.UTF8.GetString(data.Array, 0, bytesCount);

                requestBuilder.Append(textSegment);

                if (bytesCount < 1024)
                {
                    break;
                }
            }

            var requesText = requestBuilder.ToString();

            return string.IsNullOrWhiteSpace(requesText) ? null : new HttpRequest(requestBuilder.ToString());
        }
    }
}
