namespace I.SimpleHandmadeFramework.ViewEngine.Mvc
{
    using I.SimpleHandmadeFramework.ViewEngine.Mvc.Contracts;
    using System;

    public class ActionResult : IActionResult
    {
        public ActionResult(string view)
        {
            this.Action = Activator.CreateInstance(Type.GetType(view)) as IRenderable;
        }

        public IRenderable Action { get; }

        public string Invoke()
        {
            return null;
        }
    }
}
