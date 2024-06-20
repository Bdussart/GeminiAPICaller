using AutoMapper;
using BCrypt.Net;
using GeminiAPICaller.Model;
using GeminiAPICaller.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace GeminiAPICaller.Services
{


    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User user);
        void Update(int id, User user);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private DatabaseHelper _DbHelper;
        private readonly IMapper _mapper;

        public IEnumerable<User> GetAll()
        {
            return _DbHelper.Users;
        }

        public User GetById(int id)
        {
            return _DbHelper.Users.Find(id);
        }

        public void Create(User userNonNull)
        {
            // validate
            if (userNonNull != null)
            {
                if (_DbHelper.Users.Any(x => x.Id == userNonNull.Id))
                    Console.WriteLine($"User with named {userNonNull.Name} already exists");
                else
                {
                    // map model to new user object
                    var user = _mapper.Map<User>(userNonNull);

                    // hash password
                    user.Password = BCrypt.Net.BCrypt.HashPassword(userNonNull.Password);

                    // save user
                    _DbHelper.Users.Add(user);
                    _DbHelper.SaveChanges();
                }
            }
        }

        public void Update(int id, User userNonNull)
        {
            var user = _DbHelper.Users.Find(id);

            if(user != null)
            {
                // validate
                if (userNonNull.Id != user.Id && _DbHelper.Users.Any(x => x.Id == userNonNull.Id))
                    Console.WriteLine($"User with named {userNonNull.Name} already exists");

                // hash password if it was entered
                if (!string.IsNullOrEmpty(userNonNull.Password))
                    user.Password = BCrypt.Net.BCrypt.HashPassword(userNonNull.Password);

                // copy model to user and save
                _mapper.Map(userNonNull, user);
                _DbHelper.Users.Update(user);
                _DbHelper.SaveChanges();
            }
            
        }

        public void Delete(int id)
        {
            var user = _DbHelper.Users.Find(id);
            if(user != null)
            {
                _DbHelper.Users.Remove(user);
                _DbHelper.SaveChanges();
            }
        }
    }
}
