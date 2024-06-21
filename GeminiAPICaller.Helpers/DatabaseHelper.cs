using GeminiAPICaller.Model;
using System;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GeminiAPICaller.Helpers
{
    public class DatabaseHelper : DbContext
    {
        public DbSet<User> Users { get; set; }
    }

    public static User GetUser(int id)
    {
        using (var context = new AppDbContext())
        {
            return context.Users.Find(id);
        }
    }
}
