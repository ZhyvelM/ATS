using ATC.ATS.interfaces;
using ATC.ATS.Services.intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATC.ATS
{
    class PortsService : IPortsService
    {
        private Dictionary<IPort, string> availablePorts;

        public PortsService()
        {
            availablePorts = new Dictionary<IPort, string>();
        }

        private void OnDisconnect(object obj, IPhone phone)
        {
            availablePorts.FirstOrDefault(x => x.Value == phone.PhoneNumber).Key.State = PortState.Free;
        }

        public void ConnectPhoneToPort(IPhone phone, IPort port)
        {
            if (port != null && phone != null)
            {
                phone.Port = port;
                phone.Disconnect += OnDisconnect;
                port.PhoneEventsInit(phone);
                port.State = PortState.Busy;
                availablePorts.Add(port, phone.PhoneNumber);
            }
        }

        public IPort GetFreePort()
        {
            return availablePorts.FirstOrDefault(x => x.Key.State == PortState.Free).Key;
        }

        public IPort GetPortByNumber(string number)
        {
            return availablePorts.FirstOrDefault(x => x.Value == number).Key;
        }

        public IPort OpenNewPort()
        {
            IPort port = new Port();
            port.State = PortState.Free;
            return port;
        }
    }
}
