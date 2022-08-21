
using Bitirme_Projesi_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projesi_Service
{
    
    public interface IUserServices
    {
        User Signup(User oUser);
        User Login(User oUser);

    }
}
