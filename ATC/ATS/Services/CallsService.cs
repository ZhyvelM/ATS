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
                State = CallState.Unanswered
            });
            args.State = CallState.Unanswered;
        }

        public void RegisterStartedCall(CallEventArgs args)
        {
            var call = calls.Where(x => x.From == args.SourcePhoneNumber && x.To == args.AimedPhoneNumber).FirstOrDefault();
            try
            {
                call.Start();
                args.State = CallState.Calling;
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Can't find call");
            }
        }

        public void RegisterEndOfCall(CallEventArgs args)
        {
            var call = calls.Where(x => x.From == args.SourcePhoneNumber && x.To == args.AimedPhoneNumber).FirstOrDefault();
            try
            {
                call.End();
                args.State = CallState.Processed;
                calls.Remove(call);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Can't find call");
            }
        }
    }
}
