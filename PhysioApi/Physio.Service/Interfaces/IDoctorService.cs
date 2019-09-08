using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Physio.Data.Domain;
using Physio.Service.Bo;
using Physio.Service.Models;

namespace Physio.Service.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> Create(DoctorBo model);
         void Update(DoctorBo model);
        Task<Doctor> Read(int userId);
        Task<List<Doctor>> ReadAll(string name);
        Task<List<Appoiment>> ReadAppoiments();
        Task<Boolean> SendMessage(EmailModel model);
    }
}
