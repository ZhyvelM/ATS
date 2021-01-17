using ATC.ATS;
using ATC.Billing_system.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.Billing_system
{
    class CallInfo
    {
        public IAbonent From { get; set; }
        public IAbonent To { get; set; }
        public Call ATSCall { get; set; }
        public double Cost { get; set; }
        public override string ToString()
        {
            return $"From: {From.Name} To: {To.Name} Duration:{ATSCall.Duration.TotalMinutes}min Cost: {Cost}";
        }
    }
}
