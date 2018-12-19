namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics
{
    using Contracts;
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
            return this.Action.Render();
        }
    }
}
