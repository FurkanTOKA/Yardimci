using System;
using System.Collections.Generic;
using System.Text;

namespace Deneme.Common
{
    public class DefaultDeneme : IDeneme
    {
        public string GetUsername()
        {
            return "system";
        }
    }
}
