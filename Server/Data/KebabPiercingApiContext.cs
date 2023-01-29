using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KebabPiercingApi.Models;

namespace KebabPiercingApi.Data
{
    public class KebabPiercingApiContext : DbContext
    {
        public KebabPiercingApiContext (DbContextOptions<KebabPiercingApiContext> options)
            : base(options)
        {
        }

        public DbSet<KebabPiercingApi.Models.Book> Book { get; set; } = default!;
    }
}
