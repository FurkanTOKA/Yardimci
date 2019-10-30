using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme2.Common
{
    public class DefaultDeneme2 : IDeneme2
    {
        public string GetCurrentUsername()
        {
            return "system";
        }
    }
}
