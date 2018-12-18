namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Attributes
{
    using Server.Http.Enums;

    public class HttpPostAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string method)
        {
            return method.ToUpper() == HttpMethod.POST.ToString();
        }
    }
}
