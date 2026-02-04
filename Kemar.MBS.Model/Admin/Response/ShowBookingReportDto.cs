using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemar.MBS.Model.Admin.Response
{
    public class ShowBookingReportDto
    {
        public int ShowId { get; set; }
        public string MovieTitle { get; set; }
        public string TheatreName { get; set; }
        public string ScreenName { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }

        public int TotalBookings { get; set; }
        public int TicketsSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

}
