using log4net;
using Newtonsoft.Json;
using QuickFix;
using System;

namespace Acceptor_FIX
{
    internal class MyApp : MessageCracker, IApplication
    {

        private static readonly log4net.ILog log = LogManager.GetLogger(typeof(Program));

        public void OnCreate(SessionID sessionID) { }
        public void OnLogout(SessionID sessionID) { }
        public void OnLogon(SessionID sessionID) { }
        public void FromAdmin(Message msg, SessionID sessionID)
        {
            OnMessage(msg, sessionID);
        }
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
            var tipo_mensagem = ord.Header.GetString(QuickFix.Fields.Tags.MsgType);

            switch (tipo_mensagem) //remover o name dps
            {
                case "D":

                    var BeginString = ord.Header.GetString(8);
                    var BodyString = ord.Header.GetString(9);
                    var SenderCompID = ord.Header.GetString(49);
                    var TargetCompID = ord.Header.GetString(56);
                    var MsgSeqNum = ord.Header.GetString(34);
                    var SendingTime = ord.Header.GetString(52);
                    var CLOrdID = ord.GetString(11);
                    var NoPartyIDs = ord.GetString(453);
                    var Symbol = ord.GetString(55);
                    var Side = ord.GetString(54);
                    var TransactTime = ord.GetString(60);
                    var OrderQty = ord.GetString(38);
                    var OrdType = ord.GetString(40);

                    var mensagem = "BeginString: " + BeginString + ", BodyString: " + BodyString + ", SenderCompID: " + SenderCompID + ", TargetCompID: " + TargetCompID + ", MsgSeqNum: " + MsgSeqNum + ", SendingTime: " + SendingTime + ", CLOrdID: " + CLOrdID + ", NoPartyIDs: " + NoPartyIDs + ", Symbol: " + Symbol + ", Side: " + Side + ", TransactTime: " + TransactTime + ", OrderQty: " + OrderQty + ", OrdType: " + OrdType;


                    log.Info(JsonConvert.SerializeObject(mensagem));
                    break;
                default:
                    Console.WriteLine(ord);
                    break;
            }
        }
    }
}
