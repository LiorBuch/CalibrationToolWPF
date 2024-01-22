using CalibrationToolWPF.sessions.Types;
using Ivi.Visa;
using NationalInstruments.Visa;

namespace CalibrationToolWPF.sessions
{
    public sealed class SessionManager
    {
        private static Lazy<SessionManager> sessionManager = new Lazy<SessionManager>(() => new SessionManager());
        private Dictionary<string, Session> sessions = new Dictionary<string, Session>();


        private SessionManager()
        {
        }
        public static SessionManager getInstance()
        {
            return sessionManager.Value;
        }
        public bool createGPIBSession(string sessionId)
        {
            GpibSession session = new GpibSession(sessionId,AccessModes.None,5000);
            return this.sessions.TryAdd(sessionId, session);
        }
        public bool createUSBSession(string sessionId)
        {
            UsbSession session = new UsbSession(sessionId,AccessModes.None,5000);
            return this.sessions.TryAdd(sessionId, session);
        }
        public bool createLANSession(string ip)
        {
            TcpipSession session = new TcpipSession(ip, AccessModes.None, 5000);
            return this.sessions.TryAdd(ip, session);
        }
        public Session? getSession(string sessionId)
        {
            return this.sessions[sessionId];
        }
        public bool closeSession(string sessionID)
        {
           if(this.sessions.TryGetValue(sessionID, out var value))
            {
                value.Dispose();
                return value.IsDisposed;
            }
            return true;
        }
        public bool isSessionAlive(string sessionId)
        {
            if (this.sessions.TryGetValue(sessionId,out Session? session))
            {
                if(session != null)
                {
                    try
                    {
                        MessageBasedSession? msg = session as MessageBasedSession;
                        if(msg != null)
                        {
                            msg.RawIO.Write("*IDN?\n");
                            string response = msg.RawIO.ReadString();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    } catch(VisaException e)
                    {
                        return false;
                    }
                }
                else
                {
                    this.sessions.Remove(sessionId);
                    return false; // object is null;
                }
            }
            else
            {
                return false;
            }
        }
        public void closeAllSessions()
        {
            foreach(MessageBasedSession session in sessions.Values)
            {
                session.Dispose();
            }
        }

        public static List<string> getPortsList()
        {
            List<string> list = new List<string>();
            list.AddRange(getUSBPortsList());
            list.AddRange(getGPIBPortsList());
            list.AddRange(getEthernetPortsList());
            return list;
        }
        public static List<string> getUSBPortsList()
        {
            List<string> list = new List<string>();

            return list;
        }
        public static List<string> getGPIBPortsList()
        {
            List<string> list = new List<string>();

            return list;
        }
        public static List<string> getEthernetPortsList()
        {
            List<string> list = new List<string>();

            return list;
        }

    }
}
