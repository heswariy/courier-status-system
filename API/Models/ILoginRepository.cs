using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface ILoginRepository
    {
        IEnumerable<Login> GetAllLogins();
        Login GetLoginByUsername(string Username);
        Login UpdateLogin(Login login);

        //void DeleteLogin(string username);

        // int LoginCheck(Login login);

        //Login AddLogin(Login login);
    }
}
