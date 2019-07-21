using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Physio.Data.Domain;
using Physio.Service.Bo;

namespace Physio.Service.Configuration
{
   public class AutoMapper : Profile
    {
            public AutoMapper()
            {
                CreateMap<UserBo, User>().ReverseMap();
            }
       
    }
}
