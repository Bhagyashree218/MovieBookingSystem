namespace Kemar.MBS.Model.Admin.Response
{
    public class AdminLoginResponseDto
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string Token { get; set; }
    }
}
