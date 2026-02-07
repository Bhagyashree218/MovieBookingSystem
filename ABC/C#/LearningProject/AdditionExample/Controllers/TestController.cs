using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionExample.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController
    {
        [Httpget]
        public string Get()
        {
            return "api is working";
        }

    }
}
