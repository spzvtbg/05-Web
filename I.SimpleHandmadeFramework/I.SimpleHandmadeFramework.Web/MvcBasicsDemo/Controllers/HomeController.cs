namespace I.SimpleHandmadeFramework.Web.MvcBasicsDemo.Controllers
{
    using ViewEngine.MvcBasics.Contracts;
    using ViewEngine.MvcBasics.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index(ViewModel model)
        {
            return this.View();
        }
    }

    public class ViewModel
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
