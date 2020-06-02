using Communication;
using ServerLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic
{
    public class ClientAdvertSender : IObserver<AdvertReport>
    {
        private IDisposable unsubscriber;
   
        private AdvertReport lastReport;
        private WebSocketConnection socketConnection;

        public ClientAdvertSender(WebSocketConnection socketConnection)
        {
            this.socketConnection = socketConnection;
        }

        public virtual void Subscribe(IObservable<AdvertReport> provider)
        {
            unsubscriber = provider.Subscribe(this);

        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            //  do nothing
        }

        public void OnError(Exception error)
        {
            //do nothing
        }

        public void OnNext(AdvertReport value)
        {
            lastReport = value;
            
            CommunicationType cmd = new CommunicationType();
            cmd.MessageType = MESSAGE_TYPE.SEND_ADVERTS_CFM;
            cmd.Message = Serializer.Serialize(value.adverts);
            socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
           

        }

    }
}
