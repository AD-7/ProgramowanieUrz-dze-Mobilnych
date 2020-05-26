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
    public class ReportReceiver : IObserver<String>
    {
        private IDisposable unsubscriber;
        public ReportReceiver()
        {
            
        }

        public virtual void Subscribe(IObservable<String> provider)
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

        public void OnNext(String value)
        {
            File.AppendAllText("IncomeReport.txt", value);

        }

    }
}
