using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Physio.Commmon;
using Physio.Data.Domain;
using Physio.Data.Infastructure;
using Physio.Service.Interfaces;

namespace Physio.Service.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _context;
        private readonly IConfiguration configuration;

        public SecurityService(IUnitOfWork context, IConfiguration Configuration)
        {

            _context = context;
            configuration = Configuration;
        }

        public async Task<User> Login(string username, string password, Enums.UserRoles userRole)
        {
            var user = await _context.UserRepository.Read(x => x.UserName == username && x.UserRole== userRole);
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

        public async Task<bool> UserExsits(string username)
        {
            var user = await _context.UserRepository.TableAsNoTracking.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                return false;
            }
            return true;

        }

    }

}
