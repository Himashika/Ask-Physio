using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Models
{
   public class AuthResponseBo
    {
        public string Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public bool IsAdmin { get; set; }
    }
}
