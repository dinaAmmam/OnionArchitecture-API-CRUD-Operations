using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IUser
    {
        //get all record
        List<User> GetAllRepo();

        //get single record
        User GetByIdRepo(long id);

        //add record
        string AddUserRepo(User user);

        //update or edit record
        string UpdateUserRepo(User user);

        //delete record
        string DeleteUser(long id);

    }
}
