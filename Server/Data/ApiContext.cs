using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KebabPiercingApi.Models;
using BookShop.Server.Models;

namespace KebabPiercingApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;

        public DbSet<User> User { get; set; } = default!;
    }
}
