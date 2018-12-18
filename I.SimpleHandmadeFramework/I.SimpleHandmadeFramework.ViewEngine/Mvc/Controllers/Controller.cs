namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Controllers
{
    using Contracts;
    using Models;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
        }

        protected ViewModel Model { get; }

        protected IActionResult View()
        {
            return null;
        }
    }
}

