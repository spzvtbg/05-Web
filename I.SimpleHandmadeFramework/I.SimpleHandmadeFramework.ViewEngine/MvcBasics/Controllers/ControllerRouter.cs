namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Controllers
{
    using Attributes;
    using Server.Common;
    using Server.Handlers.Contracts;
    using Server.Http.Enums;
    using Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ControllerRouter : IHandleable
    {
        private readonly IDictionary<HttpMethod, IDictionary<Type, IDictionary<string, object>>> controllerTypeInfo;

        public ControllerRouter()
        {
            this.controllerTypeInfo = new Dictionary<HttpMethod, IDictionary<Type, IDictionary<string, object>>>();

            this.InitializeControllersTypeInfo();
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (request.Path.TrySplit(out string controller, out string action, Stringifier.Trim, Stringifier.Slash))
            {
                controller = controller.Replace(controller[0], char.ToUpper(controller[0]));
                action = action.Replace(action[0], char.ToUpper(action[0]));
            }
            else
            {
                throw new Exception("Invalid request path");
            }

            // Dictionary<method, <controller, <Action, object[]>>>

            return null;
        }

        private void InitializeControllersTypeInfo()
        {
            var types = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(x => x.Name.EndsWith(nameof(Controller)) && !x.IsAbstract && !x.IsInterface);

            foreach (var type in types)
            {
                var methods = type.GetMethods();

                foreach (var method in methods)
                {
                    var httpMethod = HttpMethod.GET;
                    var attribute = method.GetCustomAttributes<HttpMethodAttribute>().FirstOrDefault();

                    if (attribute != null && !attribute.IsValid(httpMethod.ToString()))
                    {
                        httpMethod = HttpMethod.POST;
                    }

                    if (!this.controllerTypeInfo.ContainsKey(httpMethod))
                    {
                        this.controllerTypeInfo[httpMethod] = new Dictionary<Type, IDictionary<string, object>>();
                    }

                    if (!this.controllerTypeInfo[httpMethod].ContainsKey(type))
                    {
                        this.controllerTypeInfo[httpMethod][type] = new Dictionary<string, object>();
                    }

                    var parameters = method.GetParameters();

                    foreach (var parameter in parameters)
                    {
                        var x = parameter;
                    }
                }
            }
        }
    }
}
