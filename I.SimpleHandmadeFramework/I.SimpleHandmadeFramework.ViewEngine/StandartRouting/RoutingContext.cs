namespace I.SimpleHandmadeFramework.ViewEngine.StandartRouting
{
    using Contracts;
    using Server.Common;
    using Server.Handlers.Contracts;
    using System.Collections.Generic;

    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(IHandleable handler, IEnumerable<string> parameters)
        {
            this.Handler = handler.EnsureNotNull() as IHandleable;
            this.Parameters = parameters.EnsureNotNull() as IEnumerable<string>;
        }

        public IEnumerable<string> Parameters  { get; private set; }

        public IHandleable Handler  { get; private set; }
    }
}
