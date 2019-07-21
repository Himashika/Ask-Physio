using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Physio.Data.Domain;
using Physio.Service.Bo;

namespace Physio.Service.Interfaces
{
    public interface IDoctorService
    {
         void Create(DoctorBo model);
         void Update(DoctorBo model);
        Task<Doctor> Read(int userId);
        Task<List<Doctor>> ReadAll();
    }
}
