using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace ViewModel
{
    public class ReportReceiver : IObserver<IncomeReport>
    {
        private IDisposable unsubscriber;
        public string startDate;
        public string endDate;
        public string income;
        private IncomeReport lastReport;

        public ReportReceiver(string startDate, string endDate, string income)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.income = income;
            
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

            File.AppendAllText("IncomeReport.txt", toFile);

        }

    }
}
