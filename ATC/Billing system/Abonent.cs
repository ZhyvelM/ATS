using ATC.ATS.interfaces;
using ATC.Billing_system.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC
{
    class Abonent : IAbonent
    {
        public string Name {get;set;}
        public IPhone Phone { get; set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} Balance: {Balance}";
        }

        public override bool Equals(object obj)
        {
            var o1 = (Abonent)obj;
            return this.Name.Equals(o1.Name);
        }
    }
}
