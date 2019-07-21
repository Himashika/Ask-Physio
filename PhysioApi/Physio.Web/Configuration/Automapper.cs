using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Physio.Service.Models;
using Physio.Web.Models;

namespace Physio.Web.Configuration
{
    public class Automapper : Profile
    {
        public Automapper()
        {
           CreateMap<UserViewModel, LoginBo>().ReverseMap();
        }
    }
}
