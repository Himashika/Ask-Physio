using Microsoft.EntityFrameworkCore;
using Physio.Commmon;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Bo;
using Physio.Service.Interfaces;
using Physio.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public async Task<Doctor> Create(DoctorBo model)
        {
            try
            {
                var userModel = new User().Create(model.Email, Enums.UserRoles.Consultant);
                var @user = await Register(userModel, model.Password);
                var @doctor = new Doctor().Create(@user.Id, model.FirstName, model.LastName, model.PhoneNo
                    , model.Hospital, model.ImageUrl, model.Email, model.Description, model.RegistrationNo, model.Address, model.Gender).AddUser(@user);

               return  await _context.DoctorRepository.CreateAndSave(@doctor);
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
        public async Task<List<Doctor>> ReadAll(string name)
        {
            try
            {
                if(name != "null")
                {
                    var result = _context.DoctorRepository.TableAsNoTracking.Where(x => x.FirstName == name).ToList();
                    return result;
                }
                else
                {
                    var result = _context.DoctorRepository.TableAsNoTracking.ToList();
                    return result;
                }
                       

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

        public async Task<List<Appoiment>> ReadAppoiments()
        {
            try
            {

                var result =  _context.AppoimentRepository.TableAsNoTracking.Where(x => x.DoctorId == 1).Include(x=>x.Doctor).ToList();
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Boolean> SendMessage(EmailModel model)
        {
            try
            {

                //MailMessage Msg = new MailMessage();
                //Msg.From = new MailAddress(model.MailFrom);
                //Msg.To.Add("himashika@gmail.com");
                //Msg.Subject = model.Subject;
                //Msg.Body = model.Description;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.Credentials = new System.Net.NetworkCredential("fernandosathya928@gmail.com", "hello928japan");
                //smtp.EnableSsl = true;
                //smtp.Send(Msg);

                //return true;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(model.MailFrom);
                msg.To.Add("himashika@gmail.com");
                msg.Subject = model.Subject;
                msg.Body = model.Description;
                //msg.Priority = MailPriority.High;


                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("fernandosathya928@gmail.com", "hello928japan");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;

                    await client.SendMailAsync(msg);
                    return true;
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                return false;
            }
        }
    }
}
