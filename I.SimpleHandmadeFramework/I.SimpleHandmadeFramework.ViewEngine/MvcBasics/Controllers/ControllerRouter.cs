namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Controllers
{
    using Attributes;
    using Contracts;
    using Server.Common;
    using Server.Handlers.Contracts;
    using Server.Http.Contracts;
    using Server.Http.Enums;
    using Server.Http.Responses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class ControllerRouter : IHandleable
    {
        private IHttpRequest request;
        private Controller controller;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.request = request;

            if (!request.Path.TrySplit(out string controller, out string action, Stringifier.Trim, Stringifier.Slash))
            {
                throw new Exception("Invalid request path");
            }

            var methodInfo = this.GetControllerActionMethods(controller, action);

            if (methodInfo == null)
            {
                return new HttpNotFoundResponse("<h1>404 - No controller found.</h1>");
            }

            var actionForExecution = this.FindSuitableAction(methodInfo);

            if (actionForExecution == null)
            {
                return new HttpNotFoundResponse("<h1>404 - No action found.</h1>");
            }

            var parameters = this.ExtractParameters(actionForExecution);

            var invocable = (IInvocable)actionForExecution.Invoke(this.controller, parameters);

            return new HttpViewResponse(invocable.Invoke());
        }

        private MethodInfo FindSuitableAction(IEnumerable<MethodInfo> controllerActions)
        {
            foreach (var action in controllerActions)
            {
                var routeAttribute = action.GetCustomAttributes<HttpMethodAttribute>().FirstOrDefault();
                var requestMethod = this.request.Method.ToString();

                if ((routeAttribute == null && requestMethod == "GET") || routeAttribute.IsValid(requestMethod))
                {
                    return action;
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetControllerActionMethods(string controller, string action)
        {
            this.controller = this.GetControllerInstance(controller);

            if (this.controller == null)
            {
                return new MethodInfo[0];
            }

            return this.controller.GetType().GetMethods().Where(m => m.Name.ToLower() == action.ToLower());
        }

        private Controller GetControllerInstance(string controller)
        {
            var controlerTypeName = string.Format("{0}.MvcBasicsDemo.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controller.Replace(controller[0], char.ToUpper(controller[0])) + "Controller");

            var controllerTypeInfo = Type.GetType(controlerTypeName);

            if (controllerTypeInfo == null)
            {
                return null;
            }

            return Activator.CreateInstance(controllerTypeInfo) as Controller;
        }

        private object[] ExtractParameters(MethodInfo actionForExecution)
        {
            var methodParameters = new List<object>();
            var parameters = actionForExecution.GetParameters();

            if (this.request.Method == HttpMethod.GET)
            {
                this.ExtractGetParameters(parameters, out methodParameters);
            }
            else
            {
                this.ExtractPostParameters(parameters, out methodParameters);
            }

            return methodParameters.ToArray();
        }

        private void ExtractPostParameters(ParameterInfo[] parameters, out List<object> values)
        {
            values = new List<object>();

            foreach (var parameter in parameters)
            {
                var parameterName = parameter.Name;
                var parameterType = parameter.ParameterType;

                if (parameterType.IsPrimitive || parameterType == typeof(string))
                {
                    var parameterValue = this.request.FormDataParameters[parameterName];

                    if (parameterValue == null)
                    {
                        parameterValue = this.request.QueryParameters[parameterName];
                    }

                    if (parameterValue != null)
                    {
                        values.Add(Convert.ChangeType(parameterValue, parameterType));
                    }
                    else
                    {
                        values.Add(parameterValue);
                    }
                }
                else
                {
                    var parameterInstance = Activator.CreateInstance(parameterType);
                    var parameterTypeProperties = parameterType.GetProperties(BindingFlags.Public);

                    foreach (var property in parameterTypeProperties)
                    {
                        var propertyValue = this.request.FormDataParameters[property.Name];

                        if (propertyValue == null)
                        {
                            continue;
                        }

                        property.SetValue(parameterInstance, propertyValue);
                    }

                    values.Add(parameterInstance);
                }
            }
        }

        private void ExtractGetParameters(ParameterInfo[] parameters, out List<object> values)
        {
            values = new List<object>();

            foreach (var parameter in parameters)
            {
                var parameterName = parameter.Name;
                var parameterType = parameter.ParameterType;

                if (parameterType.IsPrimitive || parameterType == typeof(string))
                {
                    var parameterValue = this.request.QueryParameters[parameterName];

                    if (parameterValue != null)
                    {
                        values.Add(Convert.ChangeType(parameterValue, parameterType));
                    }
                    else
                    {
                        values.Add(parameterValue);
                    }
                }
            }
        }
    }
}
