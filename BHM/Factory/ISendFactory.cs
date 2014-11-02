using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHM.Factory
{
    interface ISendFactory
    {
        ISendMethod Create(Options options);
    }
}
