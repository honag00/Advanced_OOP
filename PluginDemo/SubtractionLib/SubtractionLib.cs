using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract;

namespace SubtractionLib
{
    public class SubtractionLib : IPluginContract
    {
        public int InvokeSignature(int a, int b)
        {
            return a - b;
        }
    }
}
