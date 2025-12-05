namespace Kemar.MBS.Model.User.Response
{
    public class LoginResponseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
    }
}
