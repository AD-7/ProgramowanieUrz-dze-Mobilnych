using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic
{
    public class IncomeReport
    {
        public double Income { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public IncomeReport(double income, DateTime startDate, DateTime endDate)
        {
            Income = income;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
