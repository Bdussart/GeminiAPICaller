using Microsoft.EntityFrameworkCore;
using GeminiAPICaller.Model;

namespace GeminiAPICaller.Helpers
{
    public class DatabaseHelper : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
