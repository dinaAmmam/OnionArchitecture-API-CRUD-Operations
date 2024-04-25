using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementation
{
    public class UserService : IUser
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            
        }

        // get all users
        public List<User> GetAllRepo()
        {
            return _dbContext.tUser.ToList();
        }
        //get by id
        public User GetByIdRepo(long id)
        {
            //return _dbContext.tUser.Where(a => a.userId == id).FirstOrDefault();
            return _dbContext.tUser.Find(id);
        }
        //add user in user table
        public string AddUserRepo(User user)
        {
            try
            {
                _dbContext.tUser.Add(user);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //delete user from user table
        public string DeleteUser(long id)
        {
            try
            {
                var user = _dbContext.tUser.Find(id);
                _dbContext.Remove(user);
                _dbContext.SaveChanges() ;
                return "Successfully removed";
            }
            catch (Exception ex) 
            { 
                return ex.Message;
            }
        }

        //update user details in user table
        public string UpdateUserRepo(User user)
        {
            try
            {
                var uservalue = _dbContext.tUser.Find(user.userId);

                if (uservalue != null)
                {
                    uservalue.userName = user.userName;
                    _dbContext.Update(uservalue);
                    _dbContext.SaveChanges ();
                    return "Successfully Updated";
                }
                else
                    return "No Record(s) Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
