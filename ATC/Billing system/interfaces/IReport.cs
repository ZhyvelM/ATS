using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.Billing_system.interfaces
{
    interface IReport
    {
        public IAbonent Abonent { get; set; }
        public ICollection<CallInfo> Calls { get; set; }
    }
}
