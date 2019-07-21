using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Physio.Commmon;

namespace Physio.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PassWordHash { get; set; }
        public byte[] PassWordsalt { get; set; }
        public Enums.UserRoles UserRole { get; set; }
        public string Password { get; set; }
    }
}
