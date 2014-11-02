using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHM.Entities;

namespace BHM
{
    class SessionPayload
    {
        public ProxyServer ProxyServer { get; set; }
        public SmtpAccount SmtpAccount { get; set; }
        public SmtpServer SmtpServer { get; set; }
        public List<Email> Emails { get; set; }
        public SentStatus Status { get; set; }
        public Options Options { get; set; }
    }
}
