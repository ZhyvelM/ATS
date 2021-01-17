using System;
using System.Collections.Generic;
using System.Text;

namespace ATC.ATS
{
    class CallEventArgs
    {
        public string SourcePhoneNumber { get; set; }
        public string AimedPhoneNumber { get; set; }
        public CallState State { get; set; }
    }
}
