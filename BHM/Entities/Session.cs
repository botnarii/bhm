using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHM.Entities
{
    class Session
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public string Status { get; set; }
    }
}
