using ATC.ATS;
using ATC.ATS.interfaces;
using ATC.Billing_system.interfaces;
using ATC.Billing_system.Services;
using ATC.Billing_system.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.Billing_system
{
    class BillingSystem : IBillingSystem
    {
        private IAbonentsService abonentsService;
        private ICallsService callsService;

        public BillingSystem()
        {
            abonentsService = new AbonentsService();
            callsService = new CallsService();
            CallServiceEventInit();
        }
        public virtual void CallServiceEventInit()
        {
            callsService.PayWithdraw += OnPayWithdraw;
        }

        private void OnPayWithdraw(object sender, CallInfo call)
        { 
            call.From.Balance -= call.Cost;
        }

        public IReport GetReportForAbonent(IAbonent abonent)
        {
            IReport report = new Report()
            {
                Abonent = abonent,
                Calls = callsService.GetCallsForAbonent(abonent)
            };
            return report;
        }

        public IReport GetReportForAbonentSinceDate(IAbonent abonent, DateTime date)
        {
            IReport report = new Report()
            {
                Abonent = abonent,
                Calls = callsService.GetCallsForAbonentFrom(abonent, date)
            };
            return report;
        }

        public void RegisterAbonent(IAbonent abonent)
        {
            abonentsService.AddAbonent(abonent);
        }

        public void StationEventInit(IStation station)
        {
            station.CallService.CallHappend += OnCallHappend;
        }

        private void OnCallHappend(object sender, Call args)
        {
            CallInfo call = new CallInfo()
            {
                ATSCall = args,
                To = abonentsService.GetAbonentByNumber(args.To),
                From = abonentsService.GetAbonentByNumber(args.From)
            };
            if(args.Duration > TimeSpan.Zero)
            {
                call.Cost = args.Duration.TotalSeconds * Tariff.CostPerMinute;
                callsService.PayForCall(call);
            }
            callsService.AddCall(call);
        }
    }
}
