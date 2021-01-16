using ATC.Billing_system.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATC.Billing_system
{
    class Report : IReport
    {
        public IAbonent Abonent { get; set; }
        public ICollection<CallInfo> Calls { get; set; }

        public string GetOrderedByAbonent()
        {
            Calls = Calls.OrderBy(x => x.To).ToList();
            return this.ToString();
        }

        public string GetOrderedByCost()
        {
            Calls = Calls.OrderBy(x => x.Cost).ToList();
            return this.ToString();
        }

        public string GetOrderedByDate()
        {
            Calls = Calls.OrderBy(x => x.ATSCall.CallDate).ToList();
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Report for Abonent: {Abonent}\n");
            sb.Append(string.Join("\n", Calls));

            return sb.ToString();
        }
    }
}
