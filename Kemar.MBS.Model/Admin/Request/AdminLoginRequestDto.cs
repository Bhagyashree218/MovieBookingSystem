using Kemar.MBS.Model.Common;

namespace Kemar.MBS.Model.Admin.Request
{
    public class AdminLoginRequestDto
    {
        public string AdminEmail { get; set; }
        public string Password { get; set; }
    }
}
