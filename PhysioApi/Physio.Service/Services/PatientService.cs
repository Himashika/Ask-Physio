using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Physio.Commmon;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Bo;
using Physio.Service.Interfaces;

namespace Physio.Service.Services
{
    public class PatientService : IPatientService
    {
        private IUnitOfWork _context;
        private ISecurityService _userService;
        public PatientService(IUnitOfWork context, ISecurityService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async void Create(PatientBo model)
        {
            try
            {
                var userModel = new User().Create(model.Email, Enums.UserRoles.Patient);
                var @user = await Register(userModel, model.Password);
                var @patient = new Patient().Create(@user.Id, model.FirstName, model.LastName, model.PhoneNo
                    , model.ImageUrl, model.Email, model.Address, model.Gender).AddUser(@user);
               
             var result = await _context.PatientRepository.CreateAndSave(@patient);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async void Update(PatientBo model)
        {
            try
            {
                var @patient = new Patient().Create(model.Id, model.FirstName, model.LastName, model.PhoneNo
                   , model.ImageUrl, model.Email, model.Address, model.Gender);
                var result = await _context.PatientRepository.CreateAndSave(@patient);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Patient> Read(int userId)
        {
            try
            {

                var result = await _context.PatientRepository.Read(x => x.Id == userId);
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Patient>> ReadAll()
        {
            try
            {

                var result = _context.PatientRepository.TableAsNoTracking.Where(x => x.User.Status == Enums.RecordStatus.Active).ToList();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordhash, passwordsalt;
            GeneratePassword(password, out passwordhash, out passwordsalt);

            user.PassWordHash = passwordhash;
            user.PassWordsalt = passwordsalt;

            var result = await _context.UserRepository.CreateAndSave(user);

            return result;
        }

        private void GeneratePassword(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }
    }
}
