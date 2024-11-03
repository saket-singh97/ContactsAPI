using Microsoft.EntityFrameworkCore;
using ContactsAPI.Pattern;
using ContactsAPI.Models;
namespace ContactAPI.Database;  

    public class ContactsDbContext : DbContext  //best example of Liskov Substution principal 
    {
        //implementing Constructor Chaining 
        public ContactsDbContext(DbContextOptions dbContextOptions )   : base(dbContextOptions)   
        {
            
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder) //best example for open close principal     //open close principal base class is close for modification and derived class is open for extension 
    {
        //now need to apply linking between contact and contact mapper
        new ContactMapper(modelBuilder.Entity<Contacts>());          
    }
    public DbSet<Contacts> contacts {get; set;} //Contact will be table name 
    }
