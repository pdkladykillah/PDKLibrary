#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PDKLibrary.Models;

namespace PDKLibrary.Data
{
    public class PDKLibraryContext : DbContext
    {
        public PDKLibraryContext (DbContextOptions<PDKLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<PDKLibrary.Models.Book> Book { get; set; }
    }
}
