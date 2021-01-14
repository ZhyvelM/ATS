using ATC.Billing_system.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.Billing_system.Services.interfaces
{
    interface ICallsService
    {
        event EventHandler<CallInfo> PayWithdraw;
        void AddCall(CallInfo call);
        void PayForCall(CallInfo call);
        ICollection<CallInfo> GetCallsForAbonent(IAbonent abonent);
        ICollection<CallInfo> GetCallsForAbonentFrom(IAbonent abonent, DateTime from);
    }
}
