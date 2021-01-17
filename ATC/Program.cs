using ATC.ATS.interfaces;
using ATC.Billing_system;
using ATC.Billing_system.interfaces;
using System;

namespace ATC
{
    class Program
    {
        static void Main(string[] args)
        {
            IStation station = new Station();
            IBillingSystem bilSys = new BillingSystem();
            bilSys.StationEventInit(station);

            IPhone phone1 = new Phone() { PhoneNumber = "1" };
            IPhone phone2 = new Phone() { PhoneNumber = "2" };
            IPhone phone3 = new Phone() { PhoneNumber = "3" };
            IPhone phone4 = new Phone() { PhoneNumber = "4" };

            station.AddNewPhone(phone1);
            station.AddNewPhone(phone2);
            station.AddNewPhone(phone3);
            station.AddNewPhone(phone4);

            IAbonent abonent1 = new Abonent() { Name = "a", Phone = phone1 };
            IAbonent abonent2 = new Abonent() { Name = "b", Phone = phone2 };
            IAbonent abonent3 = new Abonent() { Name = "c", Phone = phone3 };
            IAbonent abonent4 = new Abonent() { Name = "d", Phone = phone4 };

            bilSys.RegisterAbonent(abonent1);
            bilSys.RegisterAbonent(abonent2);
            bilSys.RegisterAbonent(abonent3);
            bilSys.RegisterAbonent(abonent4);

            abonent1.Phone.Call(phone3.PhoneNumber);
            abonent3.Phone.AnswerCall();            
            abonent2.Phone.Call(phone4.PhoneNumber);
            abonent4.Phone.DropCall();
            abonent1.Phone.DropCall();

            abonent1.Phone.Call(phone2.PhoneNumber);
            abonent2.Phone.AnswerCall();            
            abonent3.Phone.Call(phone4.PhoneNumber);
            abonent4.Phone.DropCall();
            abonent1.Phone.DropCall();

            abonent1.Phone.DisconnectFromStation();

            station.AddNewPhone(abonent1.Phone);

            IReport report1 = bilSys.GetReportForAbonent(abonent1);
            Console.WriteLine(report1.GetOrderedByAbonent());
        }
    }
}
