using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RaphaelAPI.Models;

namespace RaphaelAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> produto { get; set; }
        public DbSet<Compra> compra { get; set; }
        public DbSet<Cartao> cartao { get; set; }
    }
}
