namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Controllers
{
    using Contracts;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        private string controller
        {
            get
            {
                return this.GetType().Name.Replace(MvcContext.Get.ControllersSufix, string.Empty).Trim();
            }
        }

        protected IActionResult View([CallerMemberName]string caller = "")
        {
            return new ActionResult(this.FullQualifiedViewName(caller));
        }

        protected IActionResult View(string controller, string action)
        {
            return new ActionResult(this.FullQualifiedViewName(action, controller));
        }

        protected IActionResult<TModel> View<TModel>(TModel model, [CallerMemberName]string caller = "")
        {
            return new ActionResult<TModel>(this.FullQualifiedViewName(caller), model);
        }

        protected IActionResult<TModel> View<TModel>(string controller, string action, TModel model)
        {
            return new ActionResult<TModel>(this.FullQualifiedViewName(action, controller), model);
        }

        private string FullQualifiedViewName(string action, string controller = "")
        {
            return string.Format("{0}.MvcBasicsDemo.{1}.{2}.{3}, {0}", 
                MvcContext.Get.AssemblyName, 
                MvcContext.Get.ViewsFolder, 
                string.IsNullOrWhiteSpace(controller) 
                    ? this.controller 
                    : controller, 
                action);
        }
    }
}

