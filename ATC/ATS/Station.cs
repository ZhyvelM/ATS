using ATC.ATS;
using ATC.ATS.interfaces;
using ATC.ATS.Services;
using ATC.ATS.Services.intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC
{
    class Station : IStation
    {
        private ICallsService callsService;
        private IPortsService portsService;
        public ICallsService CallService { get => callsService; }

        public Station()
        {
            callsService = new CallsService();
            portsService = new PortsService();
        }

        public void AddNewPhone(IPhone phone)
        {
            IPort port = portsService.GetFreePort();
            if (port == null)
            {
                port = portsService.OpenNewPort();
            }
            phone.Port = port;
            portsService.ConnectPhoneToPort(phone, port);
            PortEventsInit(port);
        }

        private void PortEventsInit(IPort port)
        {
            port.Call += OnCall;
            port.Answer += OnAnswer;
            port.Drop += OnDrop;
            port.StateChanged += (sender, args) =>
            {
                Console.WriteLine("port state changed");
            };
        }

        protected virtual void OnCall(object sender, CallEventArgs args)
        {
            var aimedPort = portsService.GetPortByNumber(args.AimedPhoneNumber);
            if (aimedPort != null)
            {
                if (aimedPort.State == PortState.Busy)
                {
                    aimedPort.GetIncomingCall(args);
                    callsService.RegisterDroppedCall(args);
                    Console.WriteLine("trying to call");
                }
            }
            else
            {
                Console.WriteLine("no such number");
            }
        }
        protected virtual void OnAnswer(object sender, CallEventArgs args)
        {
            args.State = CallState.Processed;
            callsService.RegisterStartedCall(args);
            Console.WriteLine("call answered");
        }

        protected virtual void OnDrop(object sender, CallEventArgs args)
        {
            if (args.State == CallState.Processed)
            {
                var callerPort = portsService.GetPortByNumber(args.SourcePhoneNumber);
                var aimedPort = portsService.GetPortByNumber(args.AimedPhoneNumber);

                callerPort.State = PortState.Busy;
                aimedPort.State = PortState.Busy;

                callsService.RegisterEndOfCall(args);

                Console.WriteLine("call ended");
            }
            else
            {
                Console.WriteLine("reciver didn't answer");
            }
            args.SourcePhoneNumber = String.Empty;
            args.AimedPhoneNumber = String.Empty;
        }
    }
}
