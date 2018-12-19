namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Contracts
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
