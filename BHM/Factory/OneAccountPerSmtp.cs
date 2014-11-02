using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHM.Factory
{
    class OneAccountPerSmtp :ISendMethod
    {
        private Options _options;

        public OneAccountPerSmtp(Options options)
        {
            _options = options;
        }
        public void Send()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<string> OnMessage;
    }
}
