namespace Kemar.MBS.Model.Auth.Request
{
    public class VerifyOtpRequestDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }

}
