namespace Kemar.MBS.Model.Admin.Response
{
    public class MovieBookingReportDto
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }

        public int TotalBookings { get; set; }
        public int TicketsSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }

}
