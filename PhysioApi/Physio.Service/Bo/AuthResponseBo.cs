using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Bo
{
    public class AuthResponseBo
    {
        public string Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public string UserRole { get; set; }
    }
}
