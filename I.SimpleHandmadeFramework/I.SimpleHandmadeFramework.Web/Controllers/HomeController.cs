namespace I.SimpleHandmadeFramework.Web.Controllers
{
    using ViewEngine.Mvc.Attributes;
    using ViewEngine.Mvc.Contracts;
    using ViewEngine.Mvc.Controllers;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(object model)
        {
            return this.View();
        }
    }
}
