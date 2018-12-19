namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Contracts
{
    public interface IActionResult<TModel> : IInvocable
    {
        IRenderable<TModel> Action { get; set; }
    }
}
