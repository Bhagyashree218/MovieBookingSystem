namespace Kemar.MBS.Model.Auth.Response
{
    public class AuthResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
