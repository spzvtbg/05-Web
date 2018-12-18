namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Contracts
{
    public interface IRedirectable : IActionResult
    {
        string RedirectUrl { get; set; }
    }
}
