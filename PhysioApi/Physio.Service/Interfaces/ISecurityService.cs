﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Physio.Commmon;
using Physio.Data.Domain;
using Physio.Service.Bo;
using Physio.Service.Models;

namespace Physio.Service.Interfaces
{
   public interface ISecurityService
    {
        Task<User> Login(string username, string password, Enums.UserRoles userRole);
        Task<User> Register(User user, string password);
        Task<bool> UserExsits(string username);
    }
}
