using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic.DataTransfer
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
