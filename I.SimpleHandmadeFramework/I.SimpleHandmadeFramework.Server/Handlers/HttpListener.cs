namespace I.SimpleHandmadeFramework.Server.Handlers
{
    using System.Net;
    using System.Net.Sockets;

    public class HttpListener
    {
        private const int HttpPort = 1369;
        private const string Localhost = "127.0.0.1";

        public static TcpListener TcpListener()
        {
            return new TcpListener(IPAddress.Parse(Localhost), HttpPort);
        }

        public static string Www()
        {
            return $"  http://localhost:{HttpPort}";
        }
    }
}
