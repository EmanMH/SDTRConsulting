using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic.Interfaces;
using Data_Access;
using System.Data;
using Utilities;

namespace Business_Logic.Services
{
    public class AdminServices : IAdminService
    {
        private readonly TimeTrackingEntities _ttContext;

        public AdminServices(TimeTrackingEntities ttContext)
        {
            _ttContext = ttContext;
        }

        public bool AddUser(IEnumerable<AspNetUser> users,string password)
        {
            try
            {
                foreach (var @user in users)
                {
                    var chck = _ttContext.AspNetUsers.FirstOrDefault(c => c.UserName == @user.UserName);
                    if (chck == null)
                    {
                        user.PasswordHash = PasswordsHelper.HashPassword(password);
                       
                        _ttContext.AspNetUsers.Add(user);
                    }
                    else
                    {
                        return false;
                    }
                }
                _ttContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddUser(IEnumerable<AspNetUser> users)
        {
            throw new NotImplementedException();
        }

        public List<AspNetUser> GetAll()
        {
            return _ttContext.AspNetUsers.ToList();
        }
    }
}
