using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHM.Entities
{
    class ProxyServer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string Status { get; set; }
    }
}
