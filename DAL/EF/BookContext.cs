using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class BookContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Book> Books { get; set; }
    
        public DbSet<Reminder> Reminders { get; set; }
    
        public DbSet<Library> Librarys { get; set; }


        // Fluent API configurations can be added here if needed
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Borrowing>()
                .HasRequired(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Borrowing>()
                .HasRequired(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.BookID)
                .WillCascadeOnDelete(false);
        }
    }
}
