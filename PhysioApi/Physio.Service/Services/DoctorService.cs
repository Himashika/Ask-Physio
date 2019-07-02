using Physio.Data.Infastructure;
using Physio.Service.Bo;
using Physio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Physio.Service.Services
{
    public class DoctorService : IDoctorService
    {
       private IUnitOfWork _Context;

        public DoctorService(IUnitOfWork Context)
            _Context = Context;
        {
        }
        public async Task<DoctorBo> Read(DoctorBo model)
        {
            try
            {
               // await _Context.DoctorRepository.CreateAndSave(model);
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
