namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Contracts
{
    using System.Collections.Generic;

    public interface IMvcConfig
    {
        string Layout { get; set; }

        string ViewsFolder { get; set; }

        string ControllersFolder { get; set; }

        ICollection<string> Routes { get; set; }
    }
}
