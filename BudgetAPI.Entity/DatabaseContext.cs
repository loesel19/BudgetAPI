using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Entity.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Entry> Entrys { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {
                if (entity is IEntity)
                {
                    var track = entity as IEntity;
                    track.DateAdded = DateTime.Now;
                    track.DateUpdated = DateTime.Now;
                }
            }

            var modified = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified)
            {
                if (entity is IEntity)
                {
                    var track = entity as IEntity;
                    track.DateUpdated = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
        /// <summary>
        /// override onModelCreating to add query filters to exclude delete flagged entities
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <author>Andrew Loesel</author>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entry>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            
            //adds data to table, use on first migration
            /*modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                AddedBy = -1,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false,
                UpdatedBy = -1,
                Username = "test",
                Password = "test"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                AddedBy = -1,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false,
                UpdatedBy = -1,
                Name = "test"
            });
            modelBuilder.Entity<Entry>().HasData(new Entry
            {
                Id = 1,
                AddedBy = -1,
                DateAdded = DateTime.Now,
                DateUpdated = DateTime.Now,
                IsDeleted = false,
                UpdatedBy = -1,
                Description = "test",
                Amount = 1
            });*/
        }

        
    }
}
