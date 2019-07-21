using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Physio.Data.Domain;
using Physio.Service.Bo;

namespace Physio.Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> Authenticate(string username, string password);
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
        ApplicationUser Create(UserBo user);
        void Update(ApplicationUser userParam, string userid);
        void Delete(int id);
    }
}
