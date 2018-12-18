namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Attributes
{
    using I.SimpleHandmadeFramework.Server.Http.Enums;

    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string method)
        {
            return method.ToUpper() == HttpMethod.GET.ToString();
        }
    }
}
