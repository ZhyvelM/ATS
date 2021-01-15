using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS.Services.intefaces
{
    interface ICallsService
    {
        event EventHandler<Call> CallHappend;
        void RegisterDroppedCall(CallEventArgs args);
        void RegisterStartedCall(CallEventArgs args);
        void RegisterEndOfCall(CallEventArgs args);
    }
}
