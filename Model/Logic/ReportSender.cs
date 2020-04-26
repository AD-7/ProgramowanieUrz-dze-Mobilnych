using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ReportSender : IObservable<IncomeReport>
    {
        private List<IObserver<IncomeReport>> observers;
        private int intervalToSendReport;
        private RestaurantManager restaurantManager;
        private DateTime lastReportDate;
        

        public ReportSender(RestaurantManager restaurantManager, int intervalToSendReport)
        {
            observers = new List<IObserver<IncomeReport>>();
            this.restaurantManager = restaurantManager;
            this.intervalToSendReport = intervalToSendReport;
            lastReportDate = DateTime.Now;
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<IncomeReport>> _observers;
            private IObserver<IncomeReport> _observer;

            public Unsubscriber(List<IObserver<IncomeReport>> observers, IObserver<IncomeReport> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
        public IDisposable Subscribe(IObserver<IncomeReport> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public void SendReport()
        {
            while(true)
            {
                DateTime sendReportDate = DateTime.Now;
                IncomeReport report = restaurantManager.GenerateIncomeReport(lastReportDate, sendReportDate);
                foreach (var observer in observers)
                    observer.OnNext(report);
                lastReportDate = sendReportDate;

                System.Threading.Thread.Sleep(intervalToSendReport);
            }
            
        }
        
    }
}
