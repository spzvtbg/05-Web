using System.Reflection;

namespace I.SimpleHandmadeFramework.ViewEngine.Mvc
{
    public class MvcContext
    {
        private static MvcContext instance;

        private MvcContext()
        {
            AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            ControllersFolder = "Controllers";
            ControllersSufix = "Controller";
            ViewsFolder = "Views";
            ModelsFolder = "Models";
        }

        public static MvcContext Get
        {
            get
            {
                return instance ?? (instance = new MvcContext());
            }
        }

        public static string AssemblyName { get; set; }

        public static string ControllersFolder { get; set; }

        public static string ControllersSufix { get; set; }

        public static string ViewsFolder { get; set; }

        public static string ModelsFolder { get; set; }
    }
}
