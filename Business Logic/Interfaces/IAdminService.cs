using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
    public interface IAdminService
    {
        bool AddUser(IEnumerable<AspNetUser> users);
        List<AspNetUser> GetAll();
    }
}
