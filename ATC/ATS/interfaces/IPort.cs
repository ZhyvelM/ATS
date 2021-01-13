using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS.interfaces
{
    interface IPort
    {
        PortState State { get; set; }

        event EventHandler<PortState> StateChanged;
        event EventHandler<CallEventArgs> Call;
        event EventHandler<CallEventArgs> Answer;
        event EventHandler<CallEventArgs> Drop;
        event EventHandler<CallEventArgs> IncomingCall;

        void GetIncomingCall(CallEventArgs connection);
        void PhoneEventsInit(IPhone phone);
    }
}
