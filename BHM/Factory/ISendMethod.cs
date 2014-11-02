using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BHM.Factory
{
    interface ISendMethod
    {
        void Send();
        void Stop();
        event EventHandler<String> OnMessage;
    }
}
