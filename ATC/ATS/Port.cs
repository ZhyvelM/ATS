using ATC.ATS.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS
{
    class Port : IPort
    {
        private PortState state;
        public PortState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                StateChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<PortState> StateChanged;
        public event EventHandler<CallEventArgs> Call;
        public event EventHandler<CallEventArgs> Answer;
        public event EventHandler<CallEventArgs> Drop;
        public event EventHandler<CallEventArgs> IncomingCall;

        public void GetIncomingCall(CallEventArgs connection)
        {
            OnIncomingCall(this, connection);
        }

        private void OnIncomingCall(object sender, CallEventArgs args)
        {
            IncomingCall?.Invoke(sender, args);
        }

        public void PhoneEventsInit(IPhone phone)
        {
            phone.IncomingCall += (sender, args) =>
            {
                State = PortState.Call;
                phone.Connection = args;
            };

            phone.OutgoingCall += (sender, args) =>
            {
                State = PortState.Call;
                Call?.Invoke(this, args);
            };

            phone.Answer += (sender, args) =>
            {
                Answer?.Invoke(this, args);
            };

            phone.Drop += (sender, args) =>
            {
                State = PortState.Busy;
                Drop?.Invoke(this, args);
            };

            this.IncomingCall += (sender, args) =>
            {
                phone.GetIncomingCall(args);
            };
        }
    }
}
