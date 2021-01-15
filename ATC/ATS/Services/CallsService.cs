using ATC.ATS.Services.intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATC.ATS.Services
{
    class CallsService : ICallsService
    {
        private ICollection<Call> calls;

        public event EventHandler<Call> CallHappend;

        public CallsService()
        {
            calls = new List<Call>();
        }

        public void RegisterDroppedCall(CallEventArgs args)
        {
            calls.Add(new Call()
            {
                From = args.SourcePhoneNumber,
                To = args.AimedPhoneNumber,
                CallDate = DateTime.Now,
                Duration = TimeSpan.Zero,
                State = CallState.Ununswered
            });
            args.State = CallState.Ununswered;
        }

        public void RegisterStartedCall(CallEventArgs args)
        {
            var call = calls.Where(x => x.From == args.SourcePhoneNumber && x.To == args.AimedPhoneNumber).FirstOrDefault();
            if (call != null)
            {
                call.CallDate = DateTime.Now;
                args.State = CallState.Calling;
                call.State = CallState.Calling;
            }
        }

        public void RegisterEndOfCall(CallEventArgs args)
        {
            var call = calls.Where(x => x.From == args.SourcePhoneNumber && x.To == args.AimedPhoneNumber).FirstOrDefault();
            if (call != null)
            {
                call.Duration = DateTime.Now - call.CallDate;

                args.State = CallState.Processed;
                call.State = CallState.Processed;

                calls.Remove(call);
            }
        }
    }
}
