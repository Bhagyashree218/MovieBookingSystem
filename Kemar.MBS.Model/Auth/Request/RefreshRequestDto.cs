namespace Kemar.MBS.Model.Auth.Request
{
    public class RefreshRequestDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
