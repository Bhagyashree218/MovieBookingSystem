using Kemar.MBS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kemar.MBS.Model.Admin.Request
{
    public class AdminCreateRequestDto : BaseRequestDto
    {
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string Password { get; set; }
    }
}
