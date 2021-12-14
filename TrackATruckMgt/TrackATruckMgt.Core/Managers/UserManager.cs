using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.Interfaces.Repositories;
using TrackATruckMgt.Core.Users;

namespace TrackATruckMgt.Core.Managers
{
    public class UserManager : IUserRepository
    {

        private readonly IUserRepository _userRepository;

        public UserManager (IUserRepository userRepository)
        {
            _userRepository = userRepository;              
        }
        public async Task<User> Login(string username, string password)
        {
            return await _userRepository.Login(username, password);
        }

        public async Task<User> Register(User user, string password)
        {
            

            return await _userRepository.Register(user, password);
        }


        //private void CreatePassWordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        //{
        //    //passwordSalt = null;
        //    //passwordHash = null;
        //    //using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    //{
        //    //    password = hmac.Key;
        //    //    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        //    //}
        //    _userRepository.CreatePassWordHash(password, out passwordSalt, out passwordHash);

        //    //  return;
        //}

        public async Task<bool> UserExists(string username)
        {
            return await _userRepository.UserExists(username);
        }

        
    }
}
