using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Bo;
using Physio.Service.Interfaces;
using Physio.Service.Models;
using AuthResponseBo = Physio.Service.Bo.AuthResponseBo;

namespace Physio.Service.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly DataContext _context;
        private readonly IConfiguration configuration;

        public SecurityService(DataContext context, IConfiguration Configuration)
        {

            _context = context;
            configuration = Configuration;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PassWordHash, user.PassWordsalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passWordHash, byte[] passWordsalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passWordsalt))
            {

                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedhash.Length; i++)
                {
                    if (passWordHash[i] != computedhash[i])
                    {
                        return false;
                    }

                }
                return true;
            };

        }

        public async Task Register(User user, string password)
        {
            byte[] passwordhash, passwordsalt;
            GeneratePassword(password, out passwordhash, out passwordsalt);

            user.PassWordHash = passwordhash;
            user.PassWordsalt = passwordsalt;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        private void GeneratePassword(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordsalt = hmac.Key;
                passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }

        public async Task<bool> UserExsits(string username)
        {
            var user = await _context.Users.AnyAsync(x => x.UserName == username);
            if (!user)
            {
                return false;
            }
            return true;

        }
     
    }

}
