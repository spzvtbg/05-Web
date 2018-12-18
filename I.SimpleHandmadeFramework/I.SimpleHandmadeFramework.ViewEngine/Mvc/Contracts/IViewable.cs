namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Contracts
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}
