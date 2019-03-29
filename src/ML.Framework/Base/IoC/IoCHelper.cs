using System;
using System.Collections.Generic;
using System.Text;

namespace ML.Framework.Base.IoC
{
    public class IoCHelper
    {
        public static IContainer Container
        {
            get
            {
                return SimpleInjectortIoC.Instance;
            }
        }
    }
}
