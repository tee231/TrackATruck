using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.Users;

namespace TrackATruckMgt.Core.Interfaces.Repositories
{
   public interface IUserRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
      
       
    }
}
