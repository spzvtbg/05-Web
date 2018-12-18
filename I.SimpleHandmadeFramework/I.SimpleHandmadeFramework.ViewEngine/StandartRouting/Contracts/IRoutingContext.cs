namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting.Contracts
{
    using Server.Handlers.Contracts;
    using System.Collections.Generic;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        IHandleable Handler { get; }
    }
}
