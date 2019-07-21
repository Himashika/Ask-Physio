
using Physio.Commmon;
using static Physio.Commmon.Enums;

namespace Physio.Service.Bo
{
    public class UserBo
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PassWordHash { get; set; }
        public byte[] PassWordsalt { get; set; }
        public Enums.UserRoles UserRole { get; set; }// Roles => Admin / Patient / Consltant 
    }
}
