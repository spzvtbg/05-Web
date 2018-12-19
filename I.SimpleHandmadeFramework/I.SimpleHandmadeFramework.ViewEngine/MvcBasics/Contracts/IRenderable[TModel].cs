namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Contracts
{
    public interface IRenderable<TModel> : IRenderable
    {
        TModel Model { get; set; }
    }
}
