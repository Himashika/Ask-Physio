using System;
using System.Collections.Generic;
using System.Text;

namespace Physio.Service.Models
{
    public class LoginBo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
