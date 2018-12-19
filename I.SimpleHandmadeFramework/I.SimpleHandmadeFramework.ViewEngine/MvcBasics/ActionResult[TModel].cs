namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics
{
    using Contracts;
    using System;

    public class ActionResult<TModel> : IActionResult<TModel>
    {
        public ActionResult(string view, TModel model)
        {
            this.Action.Model = model;
            this.Action = Activator.CreateInstance(Type.GetType(view)) as IRenderable<TModel>;
        }

        public IRenderable<TModel> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
