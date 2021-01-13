using ATC.ATS.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS.Services.intefaces
{
    interface IPortsService
    {
        void ConnectPhoneToPort(IPhone phone, IPort port);
        IPort GetPortByNumber(string number);
        IPort GetFreePort();
        IPort OpenNewPort();
    }
}
