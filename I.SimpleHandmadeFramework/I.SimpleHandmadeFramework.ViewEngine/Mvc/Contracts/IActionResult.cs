namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Contracts
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; }
    }
}
