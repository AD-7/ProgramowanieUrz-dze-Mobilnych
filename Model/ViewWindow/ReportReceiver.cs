using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ViewWindow
{
    public class ReportReceiver : IObserver<IncomeReport>
    {
        private IDisposable unsubscriber;
        private TextBox startDateTextBox;
        private TextBox endDateTextBox;
        private TextBox incomeTextBox;
        private IncomeReport lastReport;

        public ReportReceiver(TextBox startDateTextBox, TextBox endDateTextBox, TextBox incomeTextBox)
        {
            this.startDateTextBox = startDateTextBox;
            this.endDateTextBox = endDateTextBox;
            this.incomeTextBox = incomeTextBox;
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
            //do nothing
        }

        public void OnError(Exception error)
        {
            //do nothing
        }

        public void OnNext(IncomeReport value)
        {          
            lastReport = value;
            startDateTextBox.Dispatcher.Invoke(() =>
            {
                startDateTextBox.Text = lastReport.StartDate.ToString();
            });

            endDateTextBox.Dispatcher.Invoke(() =>
            {
                endDateTextBox.Text = lastReport.EndDate.ToString();
            });

            incomeTextBox.Dispatcher.Invoke(() =>
            {
                incomeTextBox.Text = lastReport.Income.ToString();
            });

        }
    }
}
