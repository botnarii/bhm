﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHM.Entities
{
    class SmtpAccount
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int SmtpServerId { get; set; }
        public string Status { get; set; }
    }
}
