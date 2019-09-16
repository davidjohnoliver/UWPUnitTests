using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.UI.DataBinding;

namespace UWPUnitTests2.Net461
{
    public class BindableMetadataProvider : IBindableMetadataProvider
    {
        public IBindableType GetBindableTypeByFullName(string fullName)
        {
            return null;
        }

        public IBindableType GetBindableTypeByType(Type type)
        {
            return null;
        }
    }
}
