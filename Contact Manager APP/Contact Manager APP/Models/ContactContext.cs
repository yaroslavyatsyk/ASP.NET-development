using Microsoft.EntityFrameworkCore;

namespace Contact_Manager_APP.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryID = 1, Name = "Family"},
                new Category() { CategoryID = 2, Name = "Friend"},
                new Category() { CategoryID = 3, Name = "Work"},
                new Category() { CategoryID = 4, Name = "Other"});

            modelBuilder.Entity<Contact>().HasData(
                new Contact() { ContactID = 1, 
                    FirstName = "Yaroslav", 
                    LastName = "Yatsyk",
                Email = "Yaroslav.Yatsyk@hotmail.com",
                CategoryID = 1,
                Phone = "647-891-1161",
                DateAdded = DateTime.Now},
                new Contact()
                {
                    ContactID = 2,
                    FirstName = "Ostap",
                    LastName = "Sulyk",
                    DateAdded = DateTime.Now,
                    CategoryID = 2,
                    Phone = "647-784-5444"
                });
            
           
        }

    }
}
