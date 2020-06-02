using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class Advertisement
    {
        public string Text { get; set; }
        public int HourFrom { get; set; }
        public int HourTo { get; set; }

        public Advertisement(string text, int hourFrom, int hourTo)
        {
            Text = text;
            HourFrom = hourFrom;
            HourTo = hourTo;
        }
    }
}
