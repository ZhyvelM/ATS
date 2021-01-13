using ATC.ATS.interfaces;
using System;

namespace ATC
{
    class Program
    {
        static void Main(string[] args)
        {
            IStation station = new Station();

            IPhone phone1 = new Phone() { PhoneNumber = "1" };
            IPhone phone2 = new Phone() { PhoneNumber = "2" };
            IPhone phone3 = new Phone() { PhoneNumber = "3" };
            IPhone phone4 = new Phone() { PhoneNumber = "4" };

            station.AddNewPhone(phone1);
            station.AddNewPhone(phone2);
            station.AddNewPhone(phone3);
            station.AddNewPhone(phone4);

            phone1.Call(phone2.PhoneNumber);
            phone2.AnswerCall();
            phone3.Call(phone4.PhoneNumber);
            phone4.DropCall();
        }
    }
}
