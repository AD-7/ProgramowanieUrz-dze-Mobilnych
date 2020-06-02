using ServerLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic
{
    public class AdvertSender : IObservable<AdvertReport>
    {
        private List<IObserver<AdvertReport>> observers;
        private int intervalToSendReport;
        private RestaurantManager restaurantManager;
        private DateTime lastReportDate;


        public AdvertSender(RestaurantManager restaurantManager, int intervalToSendReport)
        {
            observers = new List<IObserver<AdvertReport>>();
            this.restaurantManager = restaurantManager;
            this.intervalToSendReport = intervalToSendReport;
            lastReportDate = DateTime.Now;
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<AdvertReport>> _observers;
            private IObserver<AdvertReport> _observer;

            public Unsubscriber(List<IObserver<AdvertReport>> observers, IObserver<AdvertReport> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
        public IDisposable Subscribe(IObserver<AdvertReport> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public void SendReport()
        {
            while (true)
            {
                DateTime sendReportDate = DateTime.Now;
                AdvertReport report = new AdvertReport(restaurantManager.GetAdverts());
                foreach (var observer in observers)
                    observer.OnNext(report);
                lastReportDate = sendReportDate;



                System.Threading.Thread.Sleep(intervalToSendReport);
            }

        }

    }
}
