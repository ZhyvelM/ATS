using ATC.Billing_system.interfaces;
using ATC.Billing_system.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATC.Billing_system.Services
{
    class CallsService : ICallsService
    {
        private ICollection<CallInfo> calls;

        public event EventHandler<CallInfo> PayWithdraw;

        public CallsService()
        {
            calls = new List<CallInfo>();
        }

        protected virtual void OnPayWithdraw(object sender, CallInfo args)
        {
            PayWithdraw?.Invoke(sender, args);
        }

        public void AddCall(CallInfo call)
        {
            try
            {
                calls.Add(call);
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("Can't add call");
            }
        }

        public ICollection<CallInfo> GetCallsForAbonent(IAbonent abonent)
        {
            return calls.Where(x => x.From.Equals(abonent) || x.To.Equals(abonent)).ToList();
        }

        public ICollection<CallInfo> GetCallsForAbonentFrom(IAbonent abonent, DateTime from)
        {
            return calls.Where(x => (x.From.Equals(abonent) || x.To.Equals(abonent)) && x.ATSCall.CallDate >= from).ToList();
        }

        public void PayForCall(CallInfo call)
        {
            OnPayWithdraw(this, call);
        }
    }
}
