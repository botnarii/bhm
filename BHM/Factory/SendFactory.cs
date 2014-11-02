using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHM.Factory
{
    class SendFactory : ISendFactory
    {        
        public ISendMethod Create(Options options)
        {
            switch (options.Method)
            {
                case SendMethod.ThreadedWithoutProxy:
                    return ThreadedWithProxy(options);
                case SendMethod.ThreadedWithProxy:
                    return ThreadedWithoutProxy(options);
                case SendMethod.RandomAccount:
                    return RandomAccount(options);
                case SendMethod.OneAccountPerSmtp:
                    return OneAccountPerSmtp(options);
            }
            throw new Exception("Please provide a sending method!");
        }

        private ISendMethod ThreadedWithProxy(Options options)
        {
            return new ThreadedWithProxy(options);
        }

        private ISendMethod ThreadedWithoutProxy(Options options)
        {
            return new ThreadedWithoutProxy(options);
        }

        private ISendMethod RandomAccount(Options options)
        {
            return new RandomAccount(options);
        }

        private ISendMethod OneAccountPerSmtp(Options options)
        {
            return new OneAccountPerSmtp(options);
        }
    }
}