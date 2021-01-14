using ATC.ATS.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.Billing_system.interfaces
{
    interface IAbonent
    {
        string Name { get; set; }
        IPhone Phone { get; set; }
        double Balance { get; set; }
    }
}
