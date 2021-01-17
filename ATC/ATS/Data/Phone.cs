using ATC.ATS;
using ATC.ATS.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC
{
    class Phone : IPhone
    {
        public IPort Port { get; set; }

        public string PhoneNumber { get; set; }

        public CallEventArgs Connection { get;set; }

        public event EventHandler<CallEventArgs> OutgoingCall;
        public event EventHandler<CallEventArgs> IncomingCall;
        public event EventHandler<CallEventArgs> Answer;
        public event EventHandler<CallEventArgs> Drop;
        public event EventHandler<IPhone> Disconnect;

        public Phone()
        {
            Connection = new CallEventArgs() { SourcePhoneNumber = String.Empty, AimedPhoneNumber = String.Empty, State = CallState.Unanswered };
        }

        protected virtual void OnOutgoingCall(object sender, CallEventArgs args)
        {
            OutgoingCall?.Invoke(sender,args);
        }

        protected virtual void OnIncomingCall(object sender, CallEventArgs args)
        {
            IncomingCall?.Invoke(sender, args);
        }

        protected virtual void OnAnswer(object sender, CallEventArgs args)
        {
            Answer?.Invoke(sender, args);
        }

        protected virtual void OnDrop(object sender, CallEventArgs args)
        {
            Drop?.Invoke(sender, args);
        }

        public void AnswerCall()
        {
            if(Connection.SourcePhoneNumber != String.Empty)
            {
                OnAnswer(this, Connection);
            }
        }

        public void Call(string number)
        {
            if(Port != null && Port.State != PortState.Call)
            {
                Connection = new CallEventArgs
                {
                    AimedPhoneNumber = number,
                    SourcePhoneNumber = PhoneNumber
                };
                OnOutgoingCall(this, Connection);
            }
        }

        public void DropCall()
        {
            if(Connection.SourcePhoneNumber != String.Empty)
            {
                OnDrop(this, Connection);
            }
        }

        public void GetIncomingCall(CallEventArgs connection)
        {
            OnIncomingCall(this, connection);
        }

        public void DisconnectFromStation()
        {
            OnDisconnect();
        }

        private void OnDisconnect()
        {
            Disconnect?.Invoke(this, this);
            OutgoingCall = null;
            IncomingCall = null;
            Answer = null;
            Drop = null;
            Disconnect = null;
        }
    }
}
