using interviewpractice.Models;
using Microsoft.EntityFrameworkCore;

namespace interviewpractice.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<StudentModel> StudentModel { get; set; }

    }
}
