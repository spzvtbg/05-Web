namespace I.SimpleHandmadeFramework.Web.MvcBasicsDemo.Views.Home
{
    using ViewEngine.MvcBasics.Contracts;

    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h1>It works!</h1>";
        }
    }
}
