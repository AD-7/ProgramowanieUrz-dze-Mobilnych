using Dane;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ReportSender : IObservable<String>
    {
        private List<IObserver<String>> observers;
        

        public ReportSender()
        {
            observers = new List<IObserver<String>>();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<String>> _observers;
            private IObserver<String> _observer;

            public Unsubscriber(List<IObserver<String>> observers, IObserver<String> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }
        public IDisposable Subscribe(IObserver<String> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        public void SendReport(string report)
        {    
            foreach (var observer in observers)
                observer.OnNext(report);
            
        }
        
    }
}
