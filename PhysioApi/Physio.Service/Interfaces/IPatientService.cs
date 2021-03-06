﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Physio.Data.Domain;
using Physio.Service.Bo;
using Physio.Service.Models;

namespace Physio.Service.Interfaces
{
    public interface IPatientService
    {
        void Create(PatientBo model);
        void Update(PatientBo model);
        Task<Patient> Read(int userId);
        Task<List<Patient>> ReadAll();
        Task<Boolean> SendMessage(EmailModel model);
    }
}
