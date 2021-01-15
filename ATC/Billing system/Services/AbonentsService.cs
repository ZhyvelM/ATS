using ATC.Billing_system.interfaces;
using ATC.Billing_system.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATC.Billing_system.Services
{
    class AbonentsService : IAbonentsService
    {
        private ICollection<IAbonent> abonents;

        public AbonentsService()
        {
            abonents = new List<IAbonent>();
        }
        public void AddAbonent(IAbonent abonent)
        {
            if (abonent != null && abonents.Where(x => x.Name == abonent.Name).FirstOrDefault() == null)
            {
                abonents.Add(abonent);
                Console.WriteLine($"Abonent: {abonent.Name} added");
            }
            else
            {
                Console.WriteLine($"Abonent: {abonent.Name} not added");
            }
        }

        public IAbonent GetAbonentByNumber(string number)
        {
            return abonents.Where(x => x.Phone.PhoneNumber == number).FirstOrDefault();
        }
    }
}
