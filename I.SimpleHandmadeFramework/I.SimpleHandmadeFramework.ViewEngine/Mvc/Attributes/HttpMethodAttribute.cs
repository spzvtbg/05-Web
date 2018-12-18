namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Attributes
{
    using System;

    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string method);
    }
}
