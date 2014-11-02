using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BHM
{
    class SendMail
    {
        public string LastError { get; set; }

        public SendMail(SessionPayload payload)
        {
            
        }

        public bool Send(CancellationToken tokenSource)
        {
            return true;
        }
    }
}
