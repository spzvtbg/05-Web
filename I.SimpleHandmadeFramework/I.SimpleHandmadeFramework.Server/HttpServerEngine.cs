namespace I.SimpleHandmadeFramework.Server
{
    using Common;
    using Handlers;
    using Handlers.Contracts;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class HttpServerEngine : IRunnable
    {
        private bool isRunning;
        private readonly IHandleable handler;
        private readonly TcpListener tcpListener;

        public HttpServerEngine(IHandleable handler)
        {
            this.isRunning = false;
            this.handler = handler;
            this.tcpListener = HttpListener.TcpListener();
        }

        public void Run()
        {
            this.tcpListener.Start();
            this.isRunning = true;

            Logger.Log("server running on: ", HttpListener.Www());

            this.Listen().Wait();
        }

        private async Task Listen()
        {
            while (this.isRunning)
            {
                var client = await this.tcpListener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.handler);

                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}
