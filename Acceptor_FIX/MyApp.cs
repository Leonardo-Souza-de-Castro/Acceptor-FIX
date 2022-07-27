using log4net;
using Newtonsoft.Json;
using QuickFix;

namespace Acceptor_FIX
{
    internal class MyApp : MessageCracker, IApplication
    {

        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(Program));

        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { }
        public void FromAdmin(Message msg, SessionID sessionID) { }
        public void ToAdmin(Message msg, SessionID sessionID)
        {
            OnMessage(msg, sessionID);
        }
        public void ToApp(Message msg, SessionID sessionID)
        {
            OnMessage(msg, sessionID);
        }
        public void FromApp(Message message, SessionID sessionID)
        {
            OnMessage(message, sessionID);
        }

        public void OnMessage(Message ord,SessionID sessionID)
        {
            Campos_Protocolo Protocolo = new Campos_Protocolo();

            var protocol = ord.ToString().Split("");

            for (int i = 0; i <= protocol.Length - 2; i++)
            {
                var posicao = protocol[i].IndexOf('=');
                string tipo = protocol[i].Substring(0, posicao);

                switch (tipo)
                {
                    case "8":
                        Protocolo.BeginString = protocol[i].Substring(posicao + 1);
                        break;
                    case "9":
                        Protocolo.BodyLength = protocol[i].Substring(posicao + 1);
                        break;
                    case "35":
                        Protocolo.MsgType = protocol[i].Substring(posicao + 1);
                        break;
                    case "34":
                        Protocolo.MsgSeqNum = protocol[i].Substring(posicao + 1);
                        break;
                    case "49":
                        Protocolo.SenderCompID = protocol[i].Substring(posicao + 1);
                        break;
                    case "56":
                        Protocolo.TargetCompID = protocol[i].Substring(posicao + 1);
                        break;
                    case "52":
                        Protocolo.SendingTime = protocol[i].Substring(posicao + 1);
                        break;
                    case "10":
                        Protocolo.CheckSum = protocol[i].Substring(posicao + 1);
                        break;
                    case "98":
                        Protocolo.EncryptedMethod = protocol[i].Substring(posicao + 1);
                        break;
                    case "108":
                        Protocolo.HeartBtInt = protocol[i].Substring(posicao + 1);
                        break;
                    case "112":
                        Protocolo.TestReqID = protocol[i].Substring(posicao + 1);
                        break;
                    case "7":
                        Protocolo.BeginSeqNo = protocol[i].Substring(posicao + 1);
                        break;
                    case "16":
                        Protocolo.EndSeqNo = protocol[i].Substring(posicao + 1);
                        break;
                    case "11":
                        Protocolo.ClOrdID = protocol[i].Substring(posicao + 1);
                        break;
                    case "21":
                        Protocolo.HandlInst = protocol[i].Substring(posicao + 1);
                        break;
                    case "55":
                        Protocolo.Symbol = protocol[i].Substring(posicao + 1);
                        break;
                    case "54":
                        Protocolo.Side = protocol[i].Substring(posicao + 1);
                        break;
                    case "60":
                        Protocolo.TransactTime = protocol[i].Substring(posicao + 1);
                        break;
                    case "40":
                        Protocolo.OrdType = protocol[i].Substring(posicao + 1);
                        break;
                    case "44":
                        Protocolo.Price = protocol[i].Substring(posicao + 1);
                        break;
                    case "38":
                        Protocolo.OrderQty = protocol[i].Substring(posicao + 1);
                        break;
                    case "453":
                        Protocolo.NoPartyIDs = protocol[i].Substring(posicao + 1);
                        break;
                }
            }
            log.Info(JsonConvert.SerializeObject(Protocolo));
        }
    }
}
