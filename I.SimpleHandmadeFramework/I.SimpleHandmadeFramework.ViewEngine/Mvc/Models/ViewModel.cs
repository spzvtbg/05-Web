namespace I.SimpleHandmadeFramework.ViewEngine.Mvc.Models
{
    using System.Collections.Generic;

    public class ViewModel
    {
        private readonly IDictionary<string, string> data;

        public ViewModel()
        {
            this.data = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get
            {
                return this.data[key];
            }
            set
            {
                this.data[key] = value;
            }
        }
    }
}
