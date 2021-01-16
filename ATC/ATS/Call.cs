using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS
{
    class Call
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime CallDate { get; set; }
        public TimeSpan Duration { get; set; }
        public CallState State { get; set; }
        public void Start()
        {
            CallDate = DateTime.Now;
            State = CallState.Calling;
        }
        public void End()
        {
            Duration = DateTime.Now - CallDate;
            State = CallState.Processed;
        }
    }
}
