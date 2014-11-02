using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BHM.Ui;

namespace BHM
{
    class ThreadArbiter
    {
        public event EventHandler<String> OnWork;
        private readonly CancellationTokenSource _tokenSource;
        private readonly Queue<SessionPayload> _sessionPayloads;
        public int MaxThreads { get; set; }
        protected virtual void InvokeHandler(String e)
        {
            EventHandler<String> handler1 = OnWork;
            if (handler1 != null) handler1(this, e);
        }

        public ThreadArbiter()
        {
            MaxThreads = 10;
            _tokenSource = new CancellationTokenSource();
            _sessionPayloads = new Queue<SessionPayload>();
        }
        public void StartWork()
        {            
            for (var i = 0; i < MaxThreads; i++)
            {
                var theradIndex = i;
                ThreadPool.QueueUserWorkItem(s =>
                {
                    var token = (CancellationToken)s;
                    var work = true;
                    while (work)
                    {

                        var payload = _sessionPayloads.Dequeue();
                        var send = new SendMail(payload);
                        var sent = send.Send(token);
                        InvokeHandler(send.LastError);
                        if (!token.IsCancellationRequested) continue;
                        work = false;
                        System.Diagnostics.Debug.WriteLine("Canceled {0} !!", theradIndex);
                        InvokeHandler(string.Format("Thread{0} was canceled.", theradIndex));
                    }
                }, _tokenSource.Token);

            }
        }

        public void Stop()
        {
            _tokenSource.Cancel();
        }

        public void AddPayload(SessionPayload payload)
        {
            _sessionPayloads.Enqueue(payload);
        }
    }
}
