using Kemar.MBS.Model.Common;

namespace Kemar.MBS.Model.Show.Request
{
    public class ShowRequestDto : BaseRequestDto
    {
        public int ShowId { get; set; }
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public decimal Price { get; set; }
    }
}
