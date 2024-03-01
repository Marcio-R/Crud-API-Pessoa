using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudAPI.Models;

namespace CrudAPI.Data
{
    public class CrudAPIContext : DbContext
    {
        public CrudAPIContext (DbContextOptions<CrudAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CrudAPI.Models.Pessoa> Pessoa { get; set; } = default!;
    }
}
