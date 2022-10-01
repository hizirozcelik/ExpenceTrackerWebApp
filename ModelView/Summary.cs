using System;

namespace ExpenceTrackerWebApp.ModelView
{
    public class Summary
    {
        public Decimal TotalIncome { get; set; }
        public Decimal TotalExpences { get; set; }
        public Decimal AvailableMoney { get; set; }
        public Summary()
        {

        }

    }
}
