using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBasicApp.Data
{
    public class SanPhamDbContext : DbContext
    {
        public SanPhamDbContext (DbContextOptions options) : base(options)
        {

        }

        // DbSet
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Loai> Loais { get; set; }
    }
}
