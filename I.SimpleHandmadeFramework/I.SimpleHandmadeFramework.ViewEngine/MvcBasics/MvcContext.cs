namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics
{
    using System.Reflection;

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

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSufix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}
