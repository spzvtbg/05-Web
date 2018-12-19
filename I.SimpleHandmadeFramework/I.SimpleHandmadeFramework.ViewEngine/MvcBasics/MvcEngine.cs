namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics
{
    using Server.Common;
    using Server.Handlers.Contracts;
    using System;

    public class MvcEngine : IRunnable
    {
        private readonly IRunnable server;

        public MvcEngine(IRunnable server)
        {
            this.server = server;
        }

        public void Run()
        {
            try
            {
                this.server.Run();
            }
            catch (Exception ex)
            {
                Logger.Log("Error:", ex.Message);
            }
        }
    }
}
