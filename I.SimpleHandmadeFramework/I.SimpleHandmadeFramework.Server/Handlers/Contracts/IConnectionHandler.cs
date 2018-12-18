namespace I.SimpleHandmadeFramework.Server.Handlers.Contracts
{
    using System.Threading.Tasks;

    internal interface IConnectionHandler
    {
        Task ProcessRequestAsync();
    }
}
