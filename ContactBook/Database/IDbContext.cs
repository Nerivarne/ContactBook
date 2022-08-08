using ContactBook.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Database
{
    public interface IDbContext
    {

        DbSet<User> Users { get; set; }
        DbSet<Contact> Contacts { get; set; }
        IQueryable<T> Set<T>() where T : class;

        int SaveChanges();
    }
}
