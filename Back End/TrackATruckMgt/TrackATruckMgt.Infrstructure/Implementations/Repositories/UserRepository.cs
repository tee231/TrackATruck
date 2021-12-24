using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.Interfaces.Repositories;
using TrackATruckMgt.Core.Users;
using TrackATruckMgt.Data;

namespace TrackATruckMgt.Infrstructure.Implementations.Repositories
{
    class UserRepository : IUserRepository
    {

        private readonly APPContext _appContext;
       
        public UserRepository(APPContext appContext)
        {
            _appContext = appContext;
           

        }
        
        public async Task<User> Login(string username, string password)
        {
            var user =  _appContext.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            return null;

            //Authentication succesful
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; 1 <= computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[1]) 
                    return false;
                }
                return true;
            }
             
        }

        public async Task<User> Register(User user, string password)
        {
           

            byte[] passwordSalt, passwordHash;
            CreatePassWordHash(password, out passwordSalt, out passwordHash);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

             await _appContext.Users.AddAsync(user);
            await _appContext.SaveChangesAsync();
            return user;
        }

        private void CreatePassWordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            passwordSalt = null;
            passwordHash = null;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                //password = hmac.Key.ToString();
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //public async void CreatePassWordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        //{
        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        password = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }


        //}

        public async Task<bool> UserExists(string username)
        {
            if (_appContext.Users.Any(t => t.UserName == username))
            return true;

            return false;
        }
    }
}
