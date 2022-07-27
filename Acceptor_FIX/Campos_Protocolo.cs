namespace Acceptor_FIX
{

    public class Campos_Protocolo
    {
        public string BeginString { get; set; }
        public string BodyLength { get; set; }
        public string MsgType { get; set; }
        public string MsgSeqNum { get; set; }
        public string SenderCompID { get; set; }
        public string TargetCompID { get; set; }
        public string SendingTime { get; set; }
        public string CheckSum { get; set; }
        public string EncryptedMethod { get; set; }
        public string HeartBtInt { get; set; }
        public string TestReqID { get; set; }
        public string BeginSeqNo { get; set; }
        public string EndSeqNo { get; set; }
        public string ClOrdID { get; set; }
        public string HandlInst { get; set; }
        public string Symbol { get; set; }
        public string Side { get; set; }
        public string TransactTime { get; set; }
        public string OrdType { get; set; }
        public string Price { get; set; }
        public string OrderQty { get; set; }
        public string NoPartyIDs { get; set; }
    }
}
