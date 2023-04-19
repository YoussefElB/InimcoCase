using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Options;
using Models;

namespace Data
{
    public class InimcoDbContext : DbContext
    {
        public InimcoDbContext()
        {
        }

        public InimcoDbContext(DbContextOptions<InimcoDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("DataSource=../Data/Inimco.db");
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<SocialAccount> SocialAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialAccount>()
                .HasOne<Person>(s => s.Person)
                .WithMany(p => p.SocialAccounts)
                .HasForeignKey(s => s.PersonId);

            modelBuilder.Entity<Person>()
                .Property(p => p.SocialSkills)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
