using Communication;
using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic
{
    public class ClientReportSender : IObserver<IncomeReport>
    {
        private IDisposable unsubscriber;
        public string startDate;
        public string endDate;
        public string income;
        private IncomeReport lastReport;
        private WebSocketConnection socketConnection;

        public ClientReportSender(string startDate, string endDate, string income, WebSocketConnection socketConnection)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.income = income;
            this.socketConnection = socketConnection;
        }

        public virtual void Subscribe(IObservable<IncomeReport> provider)
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

        public void OnNext(IncomeReport value)
        {
            lastReport = value;

            startDate = lastReport.StartDate.ToString();

            endDate = lastReport.EndDate.ToString();

            income = lastReport.Income.ToString();

            string toFile = "";
            toFile += "--------------------------" + Environment.NewLine;
            toFile += "Report start date: " + startDate + Environment.NewLine;
            toFile += "Report end date: " + endDate + Environment.NewLine;
            toFile += "Report income: " + income + Environment.NewLine;
            toFile += "--------------------------" + Environment.NewLine;

            CommunicationType cmd = new CommunicationType();
            cmd.MessageType = MESSAGE_TYPE.SEND_REPORT_CFM;
            cmd.Message = toFile;
            socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
            //File.AppendAllText("IncomeReport.txt", toFile);

        }

    }
}
