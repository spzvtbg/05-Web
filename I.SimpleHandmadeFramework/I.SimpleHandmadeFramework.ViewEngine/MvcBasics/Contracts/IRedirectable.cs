namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Contracts
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; set; }
    }
}
