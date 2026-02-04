namespace Kemar.MBS.Model.Admin.Response
{
    public class DailySummaryDto
    {
        public DateTime Date { get; set; }
        public int TotalBookings { get; set; }
        public int TicketsSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
