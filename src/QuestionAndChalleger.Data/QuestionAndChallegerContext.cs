using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestionAndChalleger.Domain.Entities;

namespace QuestionAndChalleger.Data
{
    public class QuestionAndChallegerContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public QuestionAndChallegerContext(DbContextOptions<QuestionAndChallegerContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converterLevelToString = new EnumToStringConverter<Level>();
            var converterLevelToCategory = new EnumToStringConverter<Category>();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
                .Property(e => e.Level)
                .HasConversion(converterLevelToString);
            
            modelBuilder.Entity<Question>()
                .Property(e => e.Category)
                .HasConversion(converterLevelToCategory);
        }
    }
}
