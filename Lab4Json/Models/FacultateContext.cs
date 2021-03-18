using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4Json.Models
{
    public class FacultateContext :DbContext
    {
        public DbSet<Facultate> facultati { get; set; }

        public FacultateContext(DbContextOptions<FacultateContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
