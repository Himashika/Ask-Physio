using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Bo;

namespace Physio.Service.Services
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
    public class UserService : IUserService
    {
        private DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(DataContext context, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> Authenticate(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await _userManager.FindByNameAsync(username);


            // authentication successful
            return user;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users;
        }

        public ApplicationUser GetById(int id)
        {
            return _context.Users.Find(id);
        }


        public ApplicationUser Create(UserDto user)
        {

            var appuser = new ApplicationUser()
            {
                UserName = user.Username,

            };
            var result = _userManager.CreateAsync(appuser, user.Password).Result;

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            switch (user.Roles)
            {
                case UserRoles.Patient:
                    _userManager.AddToRoleAsync(appuser, "Patient").Wait();
                    break;
                case UserRoles.Consultant:
                    _userManager.AddToRoleAsync(appuser, "Consultant").Wait();
                    break;
            }
            return appuser;
        }

        public async void ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                //TODO throw error 
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {

            }

        }

        public async void Update(ApplicationUser userParam, string userid)
        {

            var existinguser = await _userManager.FindByIdAsync(userid);



            if (existinguser == null)
                throw new ApplicationException("User not found");

            if (userParam.UserName != existinguser.UserName)
            {
                // username has changed so check if the new username is already taken
                if (_context.Users.Any(x => x.UserName == userParam.UserName))
                    throw new ApplicationException("Username " + userParam.UserName + " is already taken");
            }

            // update user properties

            userParam.UserName = userParam.UserName;

            // TODO : update password if it was entered

            await _userManager.UpdateAsync(userParam);

        }

        public void Delete(int id)
        {
            //TODO :Delete user
        }



    }
}
}
