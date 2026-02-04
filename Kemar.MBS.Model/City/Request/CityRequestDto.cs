namespace Kemar.MBS.Model.City.Request
{
    public class CityRequestDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
