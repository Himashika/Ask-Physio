using Physio.Commmon;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Bo;
using Physio.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Physio.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _context;
        private ISecurityService _userService;

        public DoctorService(IUnitOfWork context, ISecurityService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task Create(DoctorBo model)
        {
            try
            {
                var userModel = new User().Create(model.Email, Enums.UserRoles.Consultant);
                var @user = await Register(userModel, model.Password);
                var @doctor = new Doctor().Create(@user.Id, model.FirstName, model.LastName, model.PhoneNo
                    , model.Hospital, model.ImageUrl, model.Email, model.Description, model.RegistrationNo, model.Address, model.Gender).AddUser(@user);

                await _context.DoctorRepository.CreateAndSave(@doctor);
               // using (DataContext contextt = new DataContext())
                //{
                //    var result = await contextt.Doctors.AddAsync(@doctor);
                //    contextt.SaveChangesAsync(
                //}
                    

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async void Update(DoctorBo model)
        {
            try
            {
                var @doctor = new Doctor().Create(model.Id, model.FirstName, model.LastName, model.PhoneNo
                   , model.Hospital, model.ImageUrl, model.Email, model.Description, model.RegistrationNo, model.Address, model.Gender);
                var result = await _context.DoctorRepository.CreateAndSave(@doctor);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Doctor> Read(int userId)
        {
            try
            {

                var result = await _context.DoctorRepository.Read(x => x.Id == userId);
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Doctor>> ReadAll()
        {
            try
            {

                var result = _context.DoctorRepository.TableAsNoTracking.Where(x => x.User.Status == Enums.RecordStatus.Active).ToList();
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
