using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DataTransfer
{
    public class AdvertReport
    {
        public List<AdvertisementDTG> adverts { get; private set; }



        public AdvertReport(List<AdvertisementDTG> adverts)
        {
            this.adverts = adverts;
        }

    }
}
