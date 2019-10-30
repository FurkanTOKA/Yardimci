using System;
using System.Collections.Generic;
using System.Text;

namespace YardimciCommon
{
    public class DefaultCommon : ICommon
    {
        public string GetUsername()
        {
            return "system";
        }
    }
}
