namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Contracts
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; }
    }
}
