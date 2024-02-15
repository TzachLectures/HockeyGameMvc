using HockeyGameMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HockeyGameMvc.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }


    }
}
