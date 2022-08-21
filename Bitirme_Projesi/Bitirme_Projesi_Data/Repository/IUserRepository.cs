using Bitirme_Projesi_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Data.Repository
{
    public interface IUserRepository
    {
         Task<AddUserResponse> AddUserAsync(User user);

         Task<LoginResponse> LoginUser(User user);

        
    }
}
