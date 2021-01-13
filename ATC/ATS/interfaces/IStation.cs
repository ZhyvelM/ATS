using ATC.ATS.Services.intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS.interfaces
{
    interface IStation
    {
        ICallsService CallService { get; }
        void AddNewPhone(IPhone phone);
    }
}
