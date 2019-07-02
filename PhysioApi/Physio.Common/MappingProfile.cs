using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Physio.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientViewModel, PatientBo>();
        }
    }
}
