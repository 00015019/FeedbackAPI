using Feedback_system.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Feedback_system.DAL
{
    public class FeedbackDbContext : DbContext
    {
        public DbSet<Feedback> cFeedbacks { get; set; }

        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }


}
