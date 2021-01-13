using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS.interfaces
{
    interface IPhone
    {
        IPort Port { get; set; }
        string PhoneNumber { get; set; }
        CallEventArgs Connection { get; set; }

        event EventHandler<CallEventArgs> OutgoingCall;
        event EventHandler<CallEventArgs> IncomingCall;
        event EventHandler<CallEventArgs> Answer;
        event EventHandler<CallEventArgs> Drop;

        void Call(string number);
        void GetIncomingCall(CallEventArgs connection);
        void AnswerCall();
        void DropCall();
    }
}
