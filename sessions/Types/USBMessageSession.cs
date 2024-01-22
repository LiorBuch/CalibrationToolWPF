using Ivi.Visa;
using NationalInstruments.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationToolWPF.sessions.Types
{
    public sealed class USBMessageSession : MessageBasedSession
    {
        public USBMessageSession(string resourceName, AccessModes accessModes, int openTimeout) : base(resourceName, accessModes, openTimeout)
        {
        }
    }
}
