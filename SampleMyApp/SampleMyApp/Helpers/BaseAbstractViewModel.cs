using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleMyApp.Helpers
{
    public class BaseAbstractViewModel
    {
        public virtual Task Initialize(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
