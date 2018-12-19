namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Contracts
{
    public interface IViewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}
