using System.ComponentModel.DataAnnotations;

namespace Kemar.MBS.Model.Seats.Requests
{
    public class SeatCreateRequestDto
    {
        [Required]
        public int ShowId { get; set; }

        [Required]
        public List<SeatCreateItemDto> Seats { get; set; } = new();
    }

    public class SeatCreateItemDto
    {
        [Required, MaxLength(10)]
        public string SeatNumber { get; set; }

        [MaxLength(5)]
        public string? Row { get; set; }

        [MaxLength(50)]
        public string? SeatType { get; set; }

        [Range(0, 9999)]
        public decimal Price { get; set; }
    }
}
