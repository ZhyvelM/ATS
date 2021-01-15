using ATC.ATS.interfaces;
using ATC.Billing_system.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.Billing_system.interfaces
{
    interface IBillingSystem
    {
        void StationEventInit(IStation station);
        void CallServiceEventInit();
        void RegisterAbonent(IAbonent abonent);
        IReport GetReportForAbonent(IAbonent abonent);
        IReport GetReportForAbonentSinceDate(IAbonent abonent, DateTime date);
    }
}
