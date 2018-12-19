﻿namespace I.SimpleHandmadeFramework.ViewEngine.MvcBasics.Attributes
{
    using System;

    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string method);
    }
}
