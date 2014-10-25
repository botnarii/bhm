using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHM.Entities
{
    class SmtpServer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public int WaitInterval { get; set; }
    }
}
