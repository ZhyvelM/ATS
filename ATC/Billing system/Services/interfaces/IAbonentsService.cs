using ATC.Billing_system.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.Billing_system.Services.interfaces
{
    interface IAbonentsService
    {
        void AddAbonent(IAbonent abonent);
        IAbonent GetAbonentByNumber(string number);
    }
}
