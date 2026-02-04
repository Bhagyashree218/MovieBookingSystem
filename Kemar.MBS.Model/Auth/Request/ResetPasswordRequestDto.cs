namespace Kemar.MBS.Model.Auth.Request
{
    public class ResetPasswordRequestDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
        public string NewPassword { get; set; }
    }
}
